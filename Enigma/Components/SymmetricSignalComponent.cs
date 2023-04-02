namespace Enigma.Components;

public abstract class SymmetricSignalComponent
{
    public const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    private readonly Dictionary<char, char> _forwardsMapping;

    protected SymmetricSignalComponent()
    {
        _forwardsMapping = CreateMapping(Alphabet, Alphabet);
    }

    protected Dictionary<char,char> CreateMapping(string input, string output)
    {
        var mapping = new Dictionary<char, char>();
        for (int i = 0; i < input.Length; i++)
        {
            mapping[input[i]] = output[i];
        }

        return mapping;
    }

    protected void CreateLetterPairMapping(char letter1, char letter2)
    {
        _forwardsMapping[letter1] = letter2;
        _forwardsMapping[letter2] = letter1;
    }

    protected SymmetricSignalComponent(string mappingString)
    {
        CheckMappingString(mappingString);
        
        _forwardsMapping = CreateMapping(Alphabet, mappingString);
    }

    private static void CheckMappingString(string mappingString)
    {
        if (mappingString.Length != 26 || mappingString.Any(letter => !Alphabet.Contains(letter)))
        {
            throw new ArgumentException($"Mapping string is incorrect: {mappingString}");
        }
    }

    protected char GetOutputFromMapping(char input, Dictionary<char, char> mapping)
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
        return GetOutputFromMapping(input, _forwardsMapping);
    }

    public virtual char BackwardsPass(char input)
    {
        return ForwardsPass(input);
    }

    public string GetMapping()
    {
        string output = "";

        foreach (char letter in Alphabet)
        {
            output += _forwardsMapping[letter];
        }

        return output;
    }
    
}