using Enigma.Components;
// ReSharper disable StringLiteralTypo

namespace Enigma.Builders;

public static class ReflectorBuilder
{
    public static Reflector Get(Reflector.Name name)
    {
        switch (name)
        {
            case Reflector.Name.A:
                return new Reflector(Reflector.Name.A, "EJMZALYXVBWFCRQUONTSPIKHGD");
            case Reflector.Name.B:
                return new Reflector(Reflector.Name.B, "YRUHQSLDPXNGOKMIEBFZCWVJAT");
            case Reflector.Name.C:
                return new Reflector(Reflector.Name.C, "FVPJIAOYEDRZXWGCTKUQSBNMHL");
            case Reflector.Name.BThin:
                return new Reflector(Reflector.Name.BThin, "ENKQAUYWJICOPBLMDXZVFTHRGS");
            case Reflector.Name.CThin:
                return new Reflector(Reflector.Name.CThin, "RDOBJNTKVEHMLFCWZAXGYIPSUQ");
            default: // Mirror reflector
                return new Reflector(Reflector.Name.Mirror, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }
    }

    public static Reflector Get(string name)
    {
        switch (name)
        {
            case "A":
                return Get(Reflector.Name.A);
            case "B":
                return Get(Reflector.Name.B);
            case "C":
                return Get(Reflector.Name.C);
            case "BThin":
                return Get(Reflector.Name.BThin);
            case "CThin":
                return Get(Reflector.Name.CThin);
            case "Mirror":
                return Get(Reflector.Name.Mirror);
            default:
                throw new ArgumentException($"Reflector doesn't exists: {name}");
        }
    }
}