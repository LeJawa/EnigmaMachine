using Enigma.Builders;

namespace Enigma.Components;

public class RotorAssembly
{
    private static readonly string[] ValidRotors = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII" };

    private Rotor[] _rotors;
    
    public RotorAssembly(string rotorPositions, string startPositions = "?", string ringPositions = "?")
    {
        string[] sanitizedRotorPositions = SanitizeRotorPositions(rotorPositions);

        int numberOfRotors = sanitizedRotorPositions.Length;
        _rotors = new Rotor[numberOfRotors];
        
        for (int i = 0; i < numberOfRotors; i++)
        {
            _rotors[i] = RotorBuilder.Get(sanitizedRotorPositions[i]);
        }

        if (startPositions != "?")
        {
            SetStartPositions(startPositions);
        }

        if (ringPositions != "?")
        {
            SetRingPositions(ringPositions);
        }
    }

    private string[] SanitizeRotorPositions(string rotorPositions)
    {
        if (rotorPositions.Any(c => !" IV".Contains(c)))
        {
            throw new ArgumentException($"Found unexpected characters in rotor positions: {rotorPositions}");
        }

        var splitRotorPositions = rotorPositions.Split(' ');

        if (splitRotorPositions.Any(rotorString => !ValidRotors.Contains(rotorString)))
        {
            throw new ArgumentException($"Unknown rotor in rotor positions: {rotorPositions}");
        }

        return splitRotorPositions;
    }

    public string GetTopPositions()
    {
        string topPositionsString = "";

        for (int i = 0; i < _rotors.Length; i++)
        {
            topPositionsString += new Letter(_rotors[i].TopPosition).GetChar();

            if (i != _rotors.Length - 1)
                topPositionsString += ' ';
        }

        return topPositionsString;
    }

    public void SetStartPositions(string startPositions)
    {
        char[] sanitizedStartPositions = SanitizeRotorConfiguration(startPositions);
        
        for (int i = 0; i < _rotors.Length; i++)
        {
            _rotors[i].StartPosition = new Letter(sanitizedStartPositions[i]).GetIndex();
        }
    }

    private char[] SanitizeRotorConfiguration(string startPositions)
    {
        if (startPositions.Any(c => !(char.IsLetter(c) || char.IsNumber(c) || c == ' ')))
            throw new ArgumentException($"Incorrect characters in start positions: {startPositions}");
        
        var splitStartPositions = startPositions.Split(' ');

        if (splitStartPositions.Length != _rotors.Length)
        {
            throw new ArgumentException(
                $"Incorrect number of start positions: Found {splitStartPositions.Length} and expected {_rotors.Length}");
        }

        if (splitStartPositions.Any(c => c.Length != 1))
        {
            throw new ArgumentException($"Incorrect start positions: {startPositions}");
        }

        var sanitizedStartPositions = new char[splitStartPositions.Length];
        for (int i = 0; i < splitStartPositions.Length; i++)
        {
            sanitizedStartPositions[i] = new Letter(splitStartPositions[i][0]).GetChar();
        }
        
        return sanitizedStartPositions;
    }

    public void SetRingPositions(string ringPositions)
    {
        char[] sanitizedRingPositions = SanitizeRotorConfiguration(ringPositions);
        
        for (int i = 0; i < _rotors.Length; i++)
        {
            _rotors[i].RingPosition = new Letter(sanitizedRingPositions[i]).GetIndex();
        }
    }

    public char ForwardsPass(char input)
    {
        char output = input;

        for (int i = _rotors.Length - 1; i >= 0; i--)
        {
            output = _rotors[i].ForwardsPass(output);
        }

        return output;
    }

    public char BackwardsPass(char input)
    {
        char output = input;

        for (int i = 0; i < _rotors.Length; i++)
        {
            output = _rotors[i].BackwardsPass(output);
        }

        return output;
    }

    public void Rotate()
    {
        bool[] rotorNeedsToRotate = new bool[_rotors.Length];
        
        // Rightmost rotor rotates every turn
        rotorNeedsToRotate[_rotors.Length - 1] = true;

        for (int i = _rotors.Length - 1; i >= 1; i--)
        {
            if (_rotors[i].IsInNotchPosition)
            {
                rotorNeedsToRotate[i] = true;
                rotorNeedsToRotate[i - 1] = true;
            }
        }

        for (var i = 0; i < _rotors.Length; i++)
        {
            if (rotorNeedsToRotate[i])
                _rotors[i].Rotate();
        }
    }
}