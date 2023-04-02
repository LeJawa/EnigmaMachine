namespace Enigma.Components;

public abstract class DirectionalSignalComponent : SymmetricSignalComponent
{
    private readonly Dictionary<char, char> _backwardsMapping;

    protected DirectionalSignalComponent() : base()
    {
        _backwardsMapping = CreateMapping(Alphabet, Alphabet);
    }

    protected DirectionalSignalComponent(string mappingString) : base(mappingString)
    {
        _backwardsMapping = CreateMapping(mappingString, Alphabet);
    }

    public override char BackwardsPass(char input)
    {
        return GetOutputFromMapping(input, _backwardsMapping);
    }
}