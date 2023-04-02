using System;
using Enigma.Components;
using Xunit;
// ReSharper disable StringLiteralTypo

// ReSharper disable CommentTypo

namespace EnigmaTest.Components;

public class DirectionalSignalComponentTest
{
    private class DirectionalSignalComponentTestClass : DirectionalSignalComponent
    {
        public DirectionalSignalComponentTestClass(string mapping) : base(mapping) { }

        public DirectionalSignalComponentTestClass() : base() { }
    }
    
    // DirectionalSignalComponent is child of SymmetricSignalComponent
    [Fact]
    public void TestDirectionalSignalComponentIsChildOfSymmetricSignalComponent()
    {
        DirectionalSignalComponentTestClass directionalSignalComponent = new DirectionalSignalComponentTestClass();

        Assert.IsAssignableFrom<SymmetricSignalComponent>(directionalSignalComponent);
    }
    
    
    // SignalComponent can be initialized empty constructor
    [Fact]
    public void TestExistenceOfSignalComponentEmptyConstructor()
    {
        var component = new DirectionalSignalComponentTestClass(SymmetricSignalComponent.Alphabet); 
        Assert.NotNull(component);
    }
    
    // SignalComponent can be initialized with a mapping from a string
    [Fact]
    public void TestExistenceOfSignalComponentStringConstructor()
    {
        var component = new DirectionalSignalComponentTestClass(SymmetricSignalComponent.Alphabet); 
        
        Assert.NotNull(component);
    }
    
    // Mapping = "EKMFLGDQVZNTOWYHXUSPAIBRCJ"
    [Theory]
    [InlineData('A', 'E')]
    [InlineData('E', 'L')]
    [InlineData('B', 'K')]
    [InlineData('Z', 'J')]
    public void TestForwardsPassWithNonEmptyConstructor(char input, char expectedOutput)
    {
        var component = new DirectionalSignalComponentTestClass("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
    
        char output = component.ForwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
    
    // Same tests for BackwardsPass
    [Theory]
    [InlineData('E', 'A')]
    [InlineData('L', 'E')]
    [InlineData('K', 'B')]
    [InlineData('J', 'Z')]
    public void TestBackwardsPassWithNonEmptyConstructor(char input, char expectedOutput)
    {
        var component = new DirectionalSignalComponentTestClass("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
    
        char output = component.BackwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
    
    
}