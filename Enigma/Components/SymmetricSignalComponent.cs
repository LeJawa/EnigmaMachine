namespace Enigma.Components;

public abstract class SymmetricSignalComponent
{
    public const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    protected Dictionary<char, char> ForwardsMapping;
    protected Dictionary<char, char> BackwardsMapping;

    public SymmetricSignalComponent()
    {
        ForwardsMapping = CreateMapping(Alphabet, Alphabet);
        BackwardsMapping = CreateMapping(Alphabet, Alphabet);
    }

    private Dictionary<char,char> CreateMapping(string input, string output)
    {
        var mapping = new Dictionary<char, char>();
        for (int i = 0; i < input.Length; i++)
        {
            mapping[input[i]] = output[i];
        }

        return mapping;
    }

    public SymmetricSignalComponent(string mappingString)
    {
        CheckMappingString(mappingString);
        
        ForwardsMapping = CreateMapping(Alphabet, mappingString);
        BackwardsMapping = CreateMapping(mappingString, Alphabet);
    }

    private static void CheckMappingString(string mappingString)
    {
        if (mappingString.Length != 26 || mappingString.Any(letter => !Alphabet.Contains(letter)))
        {
            throw new ArgumentException($"Mapping string is incorrect: {mappingString}");
        }
    }

    private char GetOutputFromMapping(char input, Dictionary<char, char> mapping)
    {
        char sanitizedInput = SanitizeInputLetter(input);
        return mapping[sanitizedInput];
    }

    private char SanitizeInputLetter(char input)
    {
        if (!char.IsLetter(input))
        {
            throw new ArgumentException($"The char input is not a letter: {input}");
        }

        return char.ToUpper(input);
    }

    public virtual char ForwardsPass(char input)
    {
        return GetOutputFromMapping(input, ForwardsMapping);
    }

    public virtual char BackwardsPass(char input)
    {
        return GetOutputFromMapping(input, BackwardsMapping);
    }
}