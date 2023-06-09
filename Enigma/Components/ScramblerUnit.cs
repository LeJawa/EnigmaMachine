using Enigma.Builders;

namespace Enigma.Components;

public class ScramblerUnit
{
    private readonly RotorAssembly _rotorAssembly;
    private readonly Reflector _reflector;
    
    public ScramblerUnit(string reflectorName, string rotorPositions, string rotorStartPositions = "?", string rotorRingPositions = "?")
    {
        _rotorAssembly = new RotorAssembly(rotorPositions, rotorStartPositions, rotorRingPositions);
        _reflector = ReflectorBuilder.Get(reflectorName);
    }

    public string RotorTopPositions => _rotorAssembly.GetTopPositions();

    public char Encode(char input)
    {
        _rotorAssembly.Rotate();
        char output = _rotorAssembly.ForwardsPass(input);
        output = _reflector.ForwardsPass(output);
        output = _rotorAssembly.BackwardsPass(output);

        return output;
    }
}