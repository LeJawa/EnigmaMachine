using Enigma.Components;
// ReSharper disable StringLiteralTypo

namespace Enigma.Builders;

public static class ReflectorBuilder
{
    public static Reflector Get(Reflector.Name name)
    {
        switch (name)
        {
            case Reflector.Name.B:
                return new Reflector("YRUHQSLDPXNGOKMIEBFZCWVJAT");
            case Reflector.Name.C:
                return new Reflector("FVPJIAOYEDRZXWGCTKUQSBNMHL");
            case Reflector.Name.BThin:
                return new Reflector("ENKQAUYWJICOPBLMDXZVFTHRGS");
            case Reflector.Name.CThin:
                return new Reflector("RDOBJNTKVEHMLFCWZAXGYIPSUQ");
            default: // Reflector.Name.A
                return new Reflector("EJMZALYXVBWFCRQUONTSPIKHGD");
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
            default:
                throw new ArgumentException($"Reflector doesn't exists: {name}");
        }
    }
}