namespace Enigma.Components;

public class Letter
{
    private readonly int _index;

    public Letter(int index) : this(ParseIndex(index)) { }

    private static char ParseIndex(int index)
    {
        return (char)(index + 'A');
    }

    public Letter(char letter)
    {
        if (!char.IsLetter(letter))
        {
            throw new ArgumentException($"The character is not a letter: {letter}");
        }
        
        _index = char.ToUpper(letter) - 'A';
    }

    public static Letter operator +(Letter letter, int amount)
    {
        int newIndex = letter._index + amount;
    
        newIndex = SanitizeIndex(newIndex);

        return new Letter(newIndex);
    }

    private static int SanitizeIndex(int newIndex)
    {
        while (newIndex > 25)
        {
            newIndex = (char)(newIndex - 26);
        }
        
        while (newIndex < 0)
        {
            newIndex = (char)(newIndex + 26);
        }

        return newIndex;
    }

    public static Letter operator -(Letter letter, int amount)
    {
        return letter + -amount;
    }

    public char GetChar()
    {
        return (char)(_index + 'A');
    }

    public int GetIndex()
    {
        return _index;
    }
}