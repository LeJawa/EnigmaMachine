namespace Enigma.Components;

public class Rotor : DirectionalSignalComponent
{
    private int _startPosition;
    public Rotor() : base() { }
    public Rotor(string stringMapping) : base(stringMapping) { }
    public int RingPosition { get; set; }
    public int StartPosition
    {
        get => _startPosition;
        set
        {
            _startPosition = value;
            TopPosition = value;
        }
    }

    private int TopPosition { get; set; }

    public void Rotate()
    {
        TopPosition++;
        if (TopPosition > 25)
        {
            TopPosition = 0;
        }
    }

    protected override char GetOutputFromMapping(char input, Dictionary<char, char> mapping)
    {
        char output = base.GetOutputFromMapping((char)(input - TopPosition), mapping);
        return (char)(output + TopPosition);
    }
}