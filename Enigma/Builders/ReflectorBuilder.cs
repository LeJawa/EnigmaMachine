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
}