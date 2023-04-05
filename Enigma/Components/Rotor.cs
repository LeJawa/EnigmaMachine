namespace Enigma.Components;

public class Rotor : DirectionalSignalComponent
{
    // ReSharper disable InconsistentNaming
    public enum Name
    {
        I,
        II,
        III,
        IV,
        V,
        VI,
        VII,
        VIII,
        Straight
    }
    // ReSharper restore InconsistentNaming
    
    public struct Info
    {
        public Name Name;
        public Dictionary<char, char> Mapping;
        public char TopPosition;
        public char RingSetting;
        public char[] Notch;
    }

    private readonly int[] _notches = new []{-1, -1};
    private readonly Name _name;
    
    // ReSharper disable once RedundantBaseConstructorCall
    public Rotor() : base() { }

    public Rotor(Name name, string stringMapping, char notch1 = '?', char notch2 = '?') : base(stringMapping)
    {
        _name = name;
        SetNotch(notch1, notch2);
    }

    public int RingPosition { get; set; }
    public int StartPosition
    {
        set => TopPosition = value;
    }

    public int TopPosition { get; private set; }

    public bool IsInNotchPosition => _notches.Contains(TopPosition);

    public void Rotate()
    {
        TopPosition++;
        if (TopPosition > 25)
        {
            TopPosition = 0;
        }
    }

    public override char ForwardsPass(char input)
    {
        var inputLetter = new Letter(input);

        var preOutputChar = base.ForwardsPass((inputLetter + TopPosition - RingPosition).GetChar());

        var output = new Letter(preOutputChar) - TopPosition + RingPosition;

        return output.GetChar();
    }

    public override char BackwardsPass(char input)
    {
        var inputLetter = new Letter(input);

        var preOutputChar = base.BackwardsPass((inputLetter + TopPosition - RingPosition).GetChar());

        var output = new Letter(preOutputChar) - TopPosition + RingPosition;

        return output.GetChar();
    }

    public void SetNotch(char notch1, char notch2 = '?')
    {
        if (char.IsLetter(notch1))
        {
            _notches[0] = new Letter(notch1).GetIndex();
        }

        if (char.IsLetter(notch2))
        {
            _notches[1] = new Letter(notch2).GetIndex();
        }
    }

    public Info GetInfo()
    {
        Info info = new Info
        {
            Name = _name,
            Mapping = ForwardsMapping,
            Notch = ParseNotches(),
            RingSetting = ParseRingPosition(),
            TopPosition = ParseTopPosition()
        };

        return info;
    }

    private char ParseTopPosition()
    {
        return new Letter(TopPosition).GetChar();
    }

    private char ParseRingPosition()
    {
        return new Letter(RingPosition).GetChar();
    }

    private char[] ParseNotches()
    {
        int numberOfNotches = 0;
        foreach (int notch in _notches)
        {
            if (notch != -1)
            {
                numberOfNotches++;
            }
        }

        char[] notches = new char[numberOfNotches];
        for (int i = 0; i < numberOfNotches; i++)
        {
            notches[i] = new Letter(_notches[i]).GetChar();
        }

        return notches;
    }
}