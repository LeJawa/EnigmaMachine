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
            case Rotor.Name.I:
                return new Rotor(Rotor.Name.I, "EKMFLGDQVZNTOWYHXUSPAIBRCJ", notch1: 'Q');
            case Rotor.Name.II:
                return new Rotor(Rotor.Name.II, "AJDKSIRUXBLHWTMCQGZNPYFVOE", notch1: 'E');
            case Rotor.Name.III:
                return new Rotor(Rotor.Name.III, "BDFHJLCPRTXVZNYEIWGAKMUSQO", notch1: 'V');
            case Rotor.Name.IV:
                return new Rotor(Rotor.Name.IV, "ESOVPZJAYQUIRHXLNFTGKDCMWB", notch1: 'J');
            case Rotor.Name.V:
                return new Rotor(Rotor.Name.V, "VZBRGITYUPSDNHLXAWMJQOFECK", notch1: 'Z');
            case Rotor.Name.VI:
                return new Rotor(Rotor.Name.VI, "JPGVOUMFYQBENHZRDKASXLICTW", notch1: 'Z', notch2: 'M');
            case Rotor.Name.VII:
                return new Rotor(Rotor.Name.VII, "NZJHGRCXMYSWBOUFAIVLPEKQDT", notch1: 'Z', notch2: 'M');
            case Rotor.Name.VIII:
                return new Rotor(Rotor.Name.VIII, "FKQHTLXOCBJSPDZRAMEWNIUYGV", notch1: 'Z', notch2: 'M');
            default: // Rotor.Name.Straight
                return new Rotor(Rotor.Name.Straight, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
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
            case "Straight":
                return Get(Rotor.Name.Straight);
            default:
                throw new ArgumentException($"Rotor doesn't exists: {name}");
        }
    }
}