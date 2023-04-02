using System;
using Enigma.Components;
using Xunit;

// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo

namespace EnigmaTest.Components;

public class SymmetricSignalComponentTest
{
    private class SymmetricSignalComponentTestClass : SymmetricSignalComponent
    {
        public SymmetricSignalComponentTestClass(string mapping) : base(mapping) { }

        public SymmetricSignalComponentTestClass() : base() { }
    }
    
    // SignalComponent can be initialized empty constructor
    [Fact]
    public void TestExistenceOfSignalComponentEmptyConstructor()
    {
        var component = new SymmetricSignalComponentTestClass(SymmetricSignalComponent.Alphabet); 
        Assert.NotNull(component);
    }
    
    // SignalComponent can be initialized with a mapping from a string
    [Fact]
    public void TestExistenceOfSignalComponentStringConstructor()
    {
        var component = new SymmetricSignalComponentTestClass(SymmetricSignalComponent.Alphabet); 
        
        Assert.NotNull(component);
    }
    
    // SignalComponent throws ArgumentException if non valid string is given
    [Fact]
    public void TestThrowsArgumentExceptionIfIncorrectMappingInConstructor()
    {
        Assert.Throws<ArgumentException>(() => new SymmetricSignalComponentTestClass("."));
    }
    
    // When given a letter as a char, SignalComponent.ForwardsPass returns its mapped value
    [Theory]
    [InlineData('A', 'A')]
    [InlineData('B', 'B')]
    [InlineData('Z', 'Z')]
    public void TestForwardsPassWithEmptyConstructor(char input, char expectedOutput)
    {
        var component = new SymmetricSignalComponentTestClass();
    
        char output = component.ForwardsPass(input);
        
        Assert.Equal(expectedOutput, output);
    }
    
    // Mapping = "EJMZALYXVBWFCRQUONTSPIKHGD"
    [Theory]
    [InlineData('A', 'E')]
    [InlineData('E', 'A')]
    [InlineData('B', 'J')]
    [InlineData('Z', 'D')]
    public void TestForwardsPassWithNonEmptyConstructor(char input, char expectedOutput)
    {
        var component = new SymmetricSignalComponentTestClass("EJMZALYXVBWFCRQUONTSPIKHGD");
    
        char output = component.ForwardsPass(input);
        
        Assert.Equal(expectedOutput, output);
    }
    
    // Same tests for BackwardsPass
    [Theory]
    [InlineData('A', 'A')]
    [InlineData('B', 'B')]
    [InlineData('Z', 'Z')]
    public void TestBackwardsPassWithEmptyConstructor(char input, char expectedOutput)
    {
        var component = new SymmetricSignalComponentTestClass();
    
        char output = component.BackwardsPass(input);
        
        Assert.Equal(expectedOutput, output);
    }
    
    // Mapping = "EJMZALYXVBWFCRQUONTSPIKHGD"
    [Theory]
    [InlineData('E', 'A')]
    [InlineData('A', 'E')]
    [InlineData('J', 'B')]
    [InlineData('D', 'Z')]
    public void TestBackwardsPassWithNonEmptyConstructor(char input, char expectedOutput)
    {
        var component = new SymmetricSignalComponentTestClass("EJMZALYXVBWFCRQUONTSPIKHGD");
    
        char output = component.BackwardsPass(input);
        
        Assert.Equal(expectedOutput, output);
    }
    
    // If given a non-letter character, SignalComponent throws an ArgumentException
    [Fact]
    public void TestThrowsArgumentExceptionForNonLetterCharInput()
    {
        var component = new SymmetricSignalComponentTestClass("EJMZALYXVBWFCRQUONTSPIKHGD");
    
        Assert.Throws<ArgumentException>(() =>
        {
            component.ForwardsPass('.');
        });
    }
    
}