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
    
    public Rotor() : base() { }
    public Rotor(string stringMapping) : base(stringMapping) { }
    public int RingPosition { get; set; }
    public int StartPosition
    {
        set => TopPosition = value;
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
}