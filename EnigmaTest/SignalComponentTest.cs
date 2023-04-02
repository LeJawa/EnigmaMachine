using System;
using Xunit;
using Moq;
using Enigma.Components;
// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo

namespace EnigmaTest;

public class SignalComponentTest
{
    private class SymmetricSignalComponentTest : SymmetricSignalComponent
    {
        public SymmetricSignalComponentTest(string mapping) : base(mapping) { }

        public SymmetricSignalComponentTest() : base() { }
    }
    
    // SignalComponent can be initialized empty constructor
    [Fact]
    public void TestExistenceOfSignalComponentEmptyConstructor()
    {
        var component = new SymmetricSignalComponentTest(SymmetricSignalComponent.Alphabet); 
        Assert.NotNull(component);
    }
    
    // SignalComponent can be initialized with a mapping from a string
    [Fact]
    public void TestExistenceOfSignalComponentStringConstructor()
    {
        var component = new SymmetricSignalComponentTest(SymmetricSignalComponent.Alphabet); 
        
        Assert.NotNull(component);
    }
    
    // SignalComponent throws ArgumentException if non valid string is given
    [Fact]
    public void TestThrowsArgumentExceptionIfIncorrectMappingInConstructor()
    {
        Assert.Throws<ArgumentException>(() => new SymmetricSignalComponentTest("."));
    }
    
    // When given a letter as a char, SignalComponent.ForwardsPass returns its mapped value
    [Theory]
    [InlineData('A', 'A')]
    [InlineData('B', 'B')]
    [InlineData('Z', 'Z')]
    public void TestForwardsPassWithEmptyConstructor(char input, char expectedOutput)
    {
        var component = new SymmetricSignalComponentTest();
    
        char output = component.ForwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
    
    // Mapping = "EKMFLGDQVZNTOWYHXUSPAIBRCJ"
    [Theory]
    [InlineData('A', 'E')]
    [InlineData('B', 'K')]
    [InlineData('Z', 'J')]
    public void TestForwardsPassWithNonEmptyConstructor(char input, char expectedOutput)
    {
        var component = new SymmetricSignalComponentTest("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
    
        char output = component.ForwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
    
    // Same tests for BackwardsPass
    [Theory]
    [InlineData('A', 'A')]
    [InlineData('B', 'B')]
    [InlineData('Z', 'Z')]
    public void TestBackwardsPassWithEmptyConstructor(char input, char expectedOutput)
    {
        var component = new SymmetricSignalComponentTest();
    
        char output = component.BackwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
    
    // Mapping = "EKMFLGDQVZNTOWYHXUSPAIBRCJ"
    [Theory]
    [InlineData('E', 'A')]
    [InlineData('K', 'B')]
    [InlineData('J', 'Z')]
    public void TestBackwardsPassWithNonEmptyConstructor(char input, char expectedOutput)
    {
        var component = new SymmetricSignalComponentTest("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
    
        char output = component.BackwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
    
    
    // SignalComponent can accept lowercase letters
    // Mapping = "EKMFLGDQVZNTOWYHXUSPAIBRCJ"
    [Theory]
    [InlineData('a', 'E')]
    [InlineData('b', 'K')]
    [InlineData('z', 'J')]
    public void TestLowerCaseLettersAccepted(char input, char expectedOutput)
    {
        var component = new SymmetricSignalComponentTest("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
    
        char output = component.ForwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
    
    // If given a non-letter character, SignalComponent throws an ArgumentException
    [Fact]
    public void TestThrowsArgumentExceptionForNonLetterCharInput()
    {
        var component = new SymmetricSignalComponentTest("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
    
        Assert.Throws<ArgumentException>(() =>
        {
            component.ForwardsPass('.');
        });
    }
    
}