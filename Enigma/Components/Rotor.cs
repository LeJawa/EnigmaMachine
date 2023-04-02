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
    }
    // ReSharper restore InconsistentNaming

    private int[] _notches = new []{-1, -1};
    
    // ReSharper disable once RedundantBaseConstructorCall
    public Rotor() : base() { }

    public Rotor(string stringMapping, char notch1 = '?', char notch2 = '?') : base(stringMapping)
    {
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
}