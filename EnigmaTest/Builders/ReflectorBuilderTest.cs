using System;
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
    
    [Fact]
    public void TestReflectorAWithString()
    {
        Reflector reflector = ReflectorBuilder.Get("A");
        
        Assert.Equal("EJMZALYXVBWFCRQUONTSPIKHGD", reflector.GetMapping());
    }

    // Reflector B YRUHQSLDPXNGOKMIEBFZCWVJAT
    [Fact]
    public void TestReflectorB()
    {
        Reflector reflectorB = ReflectorBuilder.Get(Reflector.Name.B);
        
        Assert.Equal("YRUHQSLDPXNGOKMIEBFZCWVJAT", reflectorB.GetMapping());
    }
    
    [Fact]
    public void TestReflectorBWithString()
    {
        Reflector reflector = ReflectorBuilder.Get("B");
        
        Assert.Equal("YRUHQSLDPXNGOKMIEBFZCWVJAT", reflector.GetMapping());
    }

    // Reflector C FVPJIAOYEDRZXWGCTKUQSBNMHL
    [Fact]
    public void TestReflectorC()
    {
        Reflector reflectorC = ReflectorBuilder.Get(Reflector.Name.C);
        
        Assert.Equal("FVPJIAOYEDRZXWGCTKUQSBNMHL", reflectorC.GetMapping());
    }
    
    [Fact]
    public void TestReflectorCWithString()
    {
        Reflector reflector = ReflectorBuilder.Get("C");
        
        Assert.Equal("FVPJIAOYEDRZXWGCTKUQSBNMHL", reflector.GetMapping());
    }

    // Reflector B thin ENKQAUYWJICOPBLMDXZVFTHRGS
    [Fact]
    public void TestReflectorBThin()
    {
        Reflector reflectorBThin = ReflectorBuilder.Get(Reflector.Name.BThin);
        
        Assert.Equal("ENKQAUYWJICOPBLMDXZVFTHRGS", reflectorBThin.GetMapping());
    }
    
    [Fact]
    public void TestReflectorBThinWithString()
    {
        Reflector reflector = ReflectorBuilder.Get("BThin");
        
        Assert.Equal("ENKQAUYWJICOPBLMDXZVFTHRGS", reflector.GetMapping());
    }

    // Reflector C thin RDOBJNTKVEHMLFCWZAXGYIPSUQ
    [Fact]
    public void TestReflectorCThin()
    {
        Reflector reflectorCThin = ReflectorBuilder.Get(Reflector.Name.CThin);
        
        Assert.Equal("RDOBJNTKVEHMLFCWZAXGYIPSUQ", reflectorCThin.GetMapping());
    }
    
    [Fact]
    public void TestReflectorCThinWithString()
    {
        Reflector reflector = ReflectorBuilder.Get("CThin");
        
        Assert.Equal("RDOBJNTKVEHMLFCWZAXGYIPSUQ", reflector.GetMapping());
    }

    // Reflector Mirror ABCDEFGHIJKLMNOPQRSTUVWXYZ
    [Fact]
    public void TestReflectorMirror()
    {
        Reflector reflectorCThin = ReflectorBuilder.Get(Reflector.Name.Mirror);
        
        Assert.Equal("ABCDEFGHIJKLMNOPQRSTUVWXYZ", reflectorCThin.GetMapping());
    }
    
    [Fact]
    public void TestReflectorMirrorWithString()
    {
        Reflector reflector = ReflectorBuilder.Get("Mirror");
        
        Assert.Equal("ABCDEFGHIJKLMNOPQRSTUVWXYZ", reflector.GetMapping());
    }
    
    [Fact]
    public void TestUnknownReflectorWithStringThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => ReflectorBuilder.Get("X"));
    }

}