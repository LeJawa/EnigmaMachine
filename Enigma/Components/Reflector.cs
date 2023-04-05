namespace Enigma.Components;

public class Reflector : SymmetricSignalComponent
{
    public enum Name
    {
        A,
        B,
        C,
        BThin,
        CThin,
        Mirror
    }
    
    public struct Info
    {
        public Name Name;
        public Dictionary<char, char> Mapping;
    }

    private readonly Name _name;

    public Reflector(Name name, string mappingString) : base(mappingString)
    {
        _name = name;
    }

    // ReSharper disable once RedundantBaseConstructorCall
    public Reflector() : base() { }

    public Info GetInfo()
    {
        Info info = new Info
        {
            Name = _name,
            Mapping = ForwardsMapping
        };

        return info;
    }
}