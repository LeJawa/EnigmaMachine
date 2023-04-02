using Enigma.Components;
// ReSharper disable StringLiteralTypo

namespace Enigma.Builders;

public static class RotorBuilder
{
    public static Rotor Get(Rotor.Name name)
    {
        switch (name)
        {
            case Rotor.Name.II:
                return new Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE");
            case Rotor.Name.III:
                return new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO");
            case Rotor.Name.IV:
                return new Rotor("ESOVPZJAYQUIRHXLNFTGKDCMWB");
            case Rotor.Name.V:
                return new Rotor("VZBRGITYUPSDNHLXAWMJQOFECK");
            case Rotor.Name.VI:
                return new Rotor("JPGVOUMFYQBENHZRDKASXLICTW");
            case Rotor.Name.VII:
                return new Rotor("NZJHGRCXMYSWBOUFAIVLPEKQDT");
            case Rotor.Name.VIII:
                return new Rotor("FKQHTLXOCBJSPDZRAMEWNIUYGV");
            default: // Rotor.Name.I
                return new Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
        }
    }
}