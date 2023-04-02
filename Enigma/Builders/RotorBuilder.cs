using Enigma.Components;
using ArgumentException = System.ArgumentException;

// ReSharper disable StringLiteralTypo

namespace Enigma.Builders;

public static class RotorBuilder
{
    public static Rotor Get(Rotor.Name name)
    {
        switch (name)
        {
            case Rotor.Name.II:
                return new Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE", 'E');
            case Rotor.Name.III:
                return new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO", 'V');
            case Rotor.Name.IV:
                return new Rotor("ESOVPZJAYQUIRHXLNFTGKDCMWB", 'J');
            case Rotor.Name.V:
                return new Rotor("VZBRGITYUPSDNHLXAWMJQOFECK", 'Z');
            case Rotor.Name.VI:
                return new Rotor("JPGVOUMFYQBENHZRDKASXLICTW", 'Z', 'M');
            case Rotor.Name.VII:
                return new Rotor("NZJHGRCXMYSWBOUFAIVLPEKQDT", 'Z', 'M');
            case Rotor.Name.VIII:
                return new Rotor("FKQHTLXOCBJSPDZRAMEWNIUYGV", 'Z', 'M');
            default: // Rotor.Name.I
                return new Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'Q');
        }
    }

    public static Rotor Get(string name)
    {
        switch (name)
        {
            case "I":
                return Get(Rotor.Name.I);
            case "II":
                return Get(Rotor.Name.II);
            case "III":
                return Get(Rotor.Name.III);
            case "IV":
                return Get(Rotor.Name.IV);
            case "V":
                return Get(Rotor.Name.V);
            case "VI":
                return Get(Rotor.Name.VI);
            case "VII":
                return Get(Rotor.Name.VII);
            case "VIII":
                return Get(Rotor.Name.VIII);
            default:
                throw new ArgumentException($"Rotor doesn't exists: {name}");
        }
    }
}