using Enigma.Builders;
using Enigma.Components;
using Xunit;
// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo
namespace EnigmaTest.Builders;

public class ReflectorBuilderTest
{
    // Reflector A EJMZALYXVBWFCRQUONTSPIKHGD
    [Fact]
    public void TestReflectorA()
    {
        Reflector reflectorA = ReflectorBuilder.Get(Reflector.Name.A);
        
        Assert.Equal("EJMZALYXVBWFCRQUONTSPIKHGD", reflectorA.GetMapping());
    }

    // Reflector B YRUHQSLDPXNGOKMIEBFZCWVJAT
    [Fact]
    public void TestReflectorB()
    {
        Reflector reflectorB = ReflectorBuilder.Get(Reflector.Name.B);
        
        Assert.Equal("YRUHQSLDPXNGOKMIEBFZCWVJAT", reflectorB.GetMapping());
    }

    // Reflector C FVPJIAOYEDRZXWGCTKUQSBNMHL
    [Fact]
    public void TestReflectorC()
    {
        Reflector reflectorC = ReflectorBuilder.Get(Reflector.Name.C);
        
        Assert.Equal("FVPJIAOYEDRZXWGCTKUQSBNMHL", reflectorC.GetMapping());
    }

    // Reflector B thin ENKQAUYWJICOPBLMDXZVFTHRGS
    [Fact]
    public void TestReflectorBThin()
    {
        Reflector reflectorBThin = ReflectorBuilder.Get(Reflector.Name.BThin);
        
        Assert.Equal("ENKQAUYWJICOPBLMDXZVFTHRGS", reflectorBThin.GetMapping());
    }

    // Reflector C thin RDOBJNTKVEHMLFCWZAXGYIPSUQ
    [Fact]
    public void TestReflectorCThin()
    {
        Reflector reflectorCThin = ReflectorBuilder.Get(Reflector.Name.CThin);
        
        Assert.Equal("RDOBJNTKVEHMLFCWZAXGYIPSUQ", reflectorCThin.GetMapping());
    }

}