using System;
using Enigma.Builders;
using Enigma.Components;
using Xunit;
// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable InconsistentNaming
namespace EnigmaTest.Builders;

public class RotorBuilderTest
{
    
    // Reflector I EKMFLGDQVZNTOWYHXUSPAIBRCJ
    [Fact]
    public void TestRotorI()
    {
        Rotor rotor = RotorBuilder.Get(Rotor.Name.I);
        
        Assert.Equal("EKMFLGDQVZNTOWYHXUSPAIBRCJ", rotor.GetMapping());
    }
    
    [Fact]
    public void TestRotorIWithString()
    {
        Rotor rotor = RotorBuilder.Get("I");
        
        Assert.Equal("EKMFLGDQVZNTOWYHXUSPAIBRCJ", rotor.GetMapping());
    }
    
    // Reflector II AJDKSIRUXBLHWTMCQGZNPYFVOE
    [Fact]
    public void TestRotorII()
    {
        Rotor rotor = RotorBuilder.Get(Rotor.Name.II);
        
        Assert.Equal("AJDKSIRUXBLHWTMCQGZNPYFVOE", rotor.GetMapping());
    }
    
    [Fact]
    public void TestRotorIIWithString()
    {
        Rotor rotor = RotorBuilder.Get("II");
        
        Assert.Equal("AJDKSIRUXBLHWTMCQGZNPYFVOE", rotor.GetMapping());
    }
    
    // Reflector III BDFHJLCPRTXVZNYEIWGAKMUSQO
    [Fact]
    public void TestRotorIII()
    {
        Rotor rotor = RotorBuilder.Get(Rotor.Name.III);
        
        Assert.Equal("BDFHJLCPRTXVZNYEIWGAKMUSQO", rotor.GetMapping());
    }
    
    [Fact]
    public void TestRotorIIIWithString()
    {
        Rotor rotor = RotorBuilder.Get("III");
        
        Assert.Equal("BDFHJLCPRTXVZNYEIWGAKMUSQO", rotor.GetMapping());
    }
    
    // Reflector IV ESOVPZJAYQUIRHXLNFTGKDCMWB
    [Fact]
    public void TestRotorIV()
    {
        Rotor rotor = RotorBuilder.Get(Rotor.Name.IV);
        
        Assert.Equal("ESOVPZJAYQUIRHXLNFTGKDCMWB", rotor.GetMapping());
    }
    
    [Fact]
    public void TestRotorIVWithString()
    {
        Rotor rotor = RotorBuilder.Get("IV");
        
        Assert.Equal("ESOVPZJAYQUIRHXLNFTGKDCMWB", rotor.GetMapping());
    }
    
    // Reflector V VZBRGITYUPSDNHLXAWMJQOFECK
    [Fact]
    public void TestRotorV()
    {
        Rotor rotor = RotorBuilder.Get(Rotor.Name.V);
        
        Assert.Equal("VZBRGITYUPSDNHLXAWMJQOFECK", rotor.GetMapping());
    }
    
    [Fact]
    public void TestRotorVWithString()
    {
        Rotor rotor = RotorBuilder.Get("V");
        
        Assert.Equal("VZBRGITYUPSDNHLXAWMJQOFECK", rotor.GetMapping());
    }
    
    // Reflector VI JPGVOUMFYQBENHZRDKASXLICTW
    [Fact]
    public void TestRotorVI()
    {
        Rotor rotor = RotorBuilder.Get(Rotor.Name.VI);
        
        Assert.Equal("JPGVOUMFYQBENHZRDKASXLICTW", rotor.GetMapping());
    }
    
    [Fact]
    public void TestRotorVIWithString()
    {
        Rotor rotor = RotorBuilder.Get("VI");
        
        Assert.Equal("JPGVOUMFYQBENHZRDKASXLICTW", rotor.GetMapping());
    }
    
    // Reflector VII NZJHGRCXMYSWBOUFAIVLPEKQDT
    [Fact]
    public void TestRotorVII()
    {
        Rotor rotor = RotorBuilder.Get(Rotor.Name.VII);
        
        Assert.Equal("NZJHGRCXMYSWBOUFAIVLPEKQDT", rotor.GetMapping());
    }
    
    [Fact]
    public void TestRotorVIIWithString()
    {
        Rotor rotor = RotorBuilder.Get("VII");
        
        Assert.Equal("NZJHGRCXMYSWBOUFAIVLPEKQDT", rotor.GetMapping());
    }
    
    // Reflector VIII FKQHTLXOCBJSPDZRAMEWNIUYGV
    [Fact]
    public void TestRotorVIII()
    {
        Rotor rotor = RotorBuilder.Get(Rotor.Name.VIII);
        
        Assert.Equal("FKQHTLXOCBJSPDZRAMEWNIUYGV", rotor.GetMapping());
    }
    
    [Fact]
    public void TestRotorVIIIWithString()
    {
        Rotor rotor = RotorBuilder.Get("VIII");
        
        Assert.Equal("FKQHTLXOCBJSPDZRAMEWNIUYGV", rotor.GetMapping());
    }
    
    [Fact]
    public void TestUnknownRotorWithStringThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => RotorBuilder.Get("X"));
    }

}