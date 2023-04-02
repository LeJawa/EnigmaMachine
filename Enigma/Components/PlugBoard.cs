namespace Enigma.Components;

public class PlugBoard : SymmetricSignalComponent
{
    public static class ErrorMessages
    {
        public static string FoundNonPairsInString(string letterPairs)
            => $"The string contains incorrect letter pairs: {letterPairs}";

        public static string FoundIncorrectCharactersInString(string letterPairs)
            => $"The string contains incorrect characters: {letterPairs}";

        public static string FoundRepeatedLetterInString(string letterPairs)
            => $"The string contains repeated letters: {letterPairs}";

        public static string FoundMoreThanTenPairsInString(string letterPairs)
            => $"The string contains more than 10 pairs of letters: {letterPairs}";
    }

    public PlugBoard()
    {
    }
    
    public PlugBoard(string letterPairs)
    {
        var sanitizedLetterPairs = SanitizeLetterPairs(letterPairs);

        foreach (string pair in sanitizedLetterPairs)
        {
            ForwardsMapping[pair[0]] = pair[1];
            ForwardsMapping[pair[1]] = pair[0];
        }
    }

    public override char BackwardsPass(char input)
    {
        return base.ForwardsPass(input);
    }

    private string[] SanitizeLetterPairs(string letterPairs)
    {
        // If not all characters are (letters or space)
        if (!letterPairs.All(c => char.IsLetter(c) || c == ' '))
        {
            throw new ArgumentException(
                ErrorMessages.FoundIncorrectCharactersInString(letterPairs));
        }

        // If letters are duplicated
        bool duplicatedLetters = false;
        for (int i = 0; i < letterPairs.Length - 1; i++)
        {
            if (duplicatedLetters)
            {
                break;
            }

            if (letterPairs[i] == ' ')
            {
                continue;
            }
            
            for (int j = i + 1; j < letterPairs.Length; j++)
            {
                if (letterPairs[i] == letterPairs[j])
                {
                    duplicatedLetters = true;
                    break;
                }
            }
        }

        if (duplicatedLetters)
        {
            throw new ArgumentException(
                ErrorMessages.FoundRepeatedLetterInString(letterPairs));
        }

        var pairs = letterPairs.Split(" ");
        
        // If any pair has length != 2
        if (pairs.Any(pair => pair.Length != 2))
        {
            throw new ArgumentException(
                ErrorMessages.FoundNonPairsInString(letterPairs));
        }

        if (pairs.Length > 10)
        {
            throw new ArgumentException(
                ErrorMessages.FoundMoreThanTenPairsInString(letterPairs));
        }
        
        return pairs;
    }
}