namespace Enigma.Components;

public class Reflector : SymmetricSignalComponent
{
    public enum Name
    {
        A,
        B,
        C,
        BThin,
        CThin
    }
    
    
    public Reflector(string mappingString) : base(mappingString) { }

    public Reflector() : base() { }
}