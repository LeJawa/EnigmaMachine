using System;
using Enigma.Components;
using Xunit;

namespace EnigmaTest.Components;

public class RotorAssemblyTest
{
    // Constructor receives string with rotor names
    // Initialize with N rotors
    [Theory]
    [InlineData("I II III")]
    [InlineData("I")]
    [InlineData("I I I I I I I I I I I I I")]
    public void TestConstructor(string rotorPositions)
    {
        RotorAssembly rotorAssembly = new RotorAssembly(rotorPositions);
    }
    
    // Constructor throws ArgumentException if string not properly formatted or unknown rotor
    [Theory]
    [InlineData("I II IIV")]
    [InlineData(".")]
    [InlineData("I I .")]
    public void TestConstructorThrowsArgumentException(string rotorPositions)
    {
        Assert.Throws<ArgumentException>(() => new RotorAssembly(rotorPositions));
    }
    
    // GetTopPositions
    [Theory]
    [InlineData("I II III", "A A A")]
    [InlineData("I", "A")]
    public void TestGetTopPositions(string rotorPositions, string expectedTopPositions)
    {
        RotorAssembly rotorAssembly = new RotorAssembly(rotorPositions);

        string output = rotorAssembly.GetTopPositions();
        
        Assert.Equal(expectedTopPositions, output);
    }
    
    // SetStartPositions
    [Theory]
    [InlineData("I II III", "A B C")]
    [InlineData("I", "Z")]
    public void TestSetStartPositions(string rotorPositions, string startPositions)
    {
        RotorAssembly rotorAssembly = new RotorAssembly(rotorPositions);
        rotorAssembly.SetStartPositions(startPositions);
        
        string output = rotorAssembly.GetTopPositions();
        
        Assert.Equal(startPositions, output);
    }
    
    // SetStartPositions throws ArgumentException if incorrect input
    [Theory]
    [InlineData("I II III", "A B")]
    [InlineData("I", ".")]
    public void TestSetStartPositionsThrowsArgumentExceptions(string rotorPositions, string startPositions)
    {
        RotorAssembly rotorAssembly = new RotorAssembly(rotorPositions);
        Assert.Throws<ArgumentException>(() => rotorAssembly.SetStartPositions(startPositions));
    }
    
    // SetRingPositions
    [Theory]
    [InlineData("I II III", "A B C")]
    [InlineData("I", "Z")]
    public void TestSetRingPositions(string rotorPositions, string startPositions)
    {
        RotorAssembly rotorAssembly = new RotorAssembly(rotorPositions);
        rotorAssembly.SetRingPositions(startPositions);
    }
    
    // SetRingPositions throws ArgumentException if incorrect input
    [Theory]
    [InlineData("I II III", "A B")]
    [InlineData("I", ".")]
    public void TestSetRingPositionsThrowsArgumentExceptions(string rotorPositions, string startPositions)
    {
        RotorAssembly rotorAssembly = new RotorAssembly(rotorPositions);
        Assert.Throws<ArgumentException>(() => rotorAssembly.SetRingPositions(startPositions));
    }
    
    // Rotate
    [Theory]
    [InlineData("I", "B")]
    [InlineData("II I", "A B")]
    public void TestRotate(string rotorPositions, string expectedTopPositions)
    {
        RotorAssembly rotorAssembly = new RotorAssembly(rotorPositions);

        rotorAssembly.Rotate();
        var output = rotorAssembly.GetTopPositions();
        
        Assert.Equal(expectedTopPositions, output);
    }
    
    // Single step
    [Theory]
    [InlineData("I", "Q", "R")]
    [InlineData("II I", "A Q", "B R")]
    public void TestSingleStep(string rotorPositions, string startPositions, string expectedTopPositions)
    {
        RotorAssembly rotorAssembly = new RotorAssembly(rotorPositions);
        rotorAssembly.SetStartPositions(startPositions);

        rotorAssembly.Rotate();
        var output = rotorAssembly.GetTopPositions();
        
        Assert.Equal(expectedTopPositions, output);
    }
    
    // Double step
    [Theory]
    [InlineData("II I", "E Q", "F R")]
    [InlineData("III II I", "A E Q", "B F R")]
    public void TestDoubleStep(string rotorPositions, string startPositions, string expectedTopPositions)
    {
        RotorAssembly rotorAssembly = new RotorAssembly(rotorPositions);
        rotorAssembly.SetStartPositions(startPositions);
        
        rotorAssembly.Rotate();
        var output = rotorAssembly.GetTopPositions();
        
        Assert.Equal(expectedTopPositions, output);
    }
    
    // ForwardsPass
    [Theory]
    [InlineData("I", 'A', 'E')]
    [InlineData("II I", 'A', 'S')]
    public void TestForwardsPass(string rotorPositions, char input, char expectedOutput)
    {
        RotorAssembly rotorAssembly = new RotorAssembly(rotorPositions);

        char output = rotorAssembly.ForwardsPass(input);
        
        Assert.Equal(expectedOutput, output);
    }
    
    // BackwardsPass
    [Theory]
    [InlineData("I", 'E', 'A')]
    [InlineData("II I", 'F', 'N')]
    public void TestBackwardsPass(string rotorPositions, char input, char expectedOutput)
    {
        RotorAssembly rotorAssembly = new RotorAssembly(rotorPositions);

        char output = rotorAssembly.BackwardsPass(input);
        
        Assert.Equal(expectedOutput, output);
    }
}