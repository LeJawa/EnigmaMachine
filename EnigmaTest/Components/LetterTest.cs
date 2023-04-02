using System;
using System.Runtime.InteropServices;
using Enigma.Components;
using Xunit;

namespace EnigmaTest.Components;

public class LetterTest
{
    // Letter can return char value
    [Fact]
    public void LetterGetsCharValue()
    {
        var letter = new Letter('A');

        char output = letter.GetChar();
        
        Assert.Equal('A', output);
    }
    
    // Letter can return index value
    [Fact]
    public void LetterGetsIndexValue()
    {
        var letter = new Letter('Z');
        int index = letter.GetIndex();
        
        Assert.Equal(25, index);
    }
    
    // Letter accepts lowercase and uppercase char inputs
    [Fact]
    public void LetterAcceptsLowercase()
    {
        var letter = new Letter('a');

        char output = letter.GetChar();
        
        Assert.Equal('A', output);
    }
    
    // Letter throws ArgumentException if non letter in constructor
    [Fact]
    public void LetterThrowsArgumentExceptionForNonLetters()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var letter = new Letter('.');
        });
    }
    
    // + operator increments letter
    [Theory]
    [InlineData('A', 1, 'B')]
    [InlineData('A', 2, 'C')]
    public void LetterCanBeIncremented(char input, int increment, char expectedOutput)
    {
        var letter = new Letter(input);
        var outputLetter = letter + increment;
        char output = outputLetter.GetChar();
        
        Assert.Equal(expectedOutput, output);
    }
    
    // - operator decrements letter
    [Theory]
    [InlineData('Z', 1, 'Y')]
    [InlineData('Z', 2, 'X')]
    public void LetterCanBeDecremented(char input, int decrement, char expectedOutput)
    {
        var letter = new Letter(input);
        var outputLetter = letter - decrement;
        char output = outputLetter.GetChar();
        
        Assert.Equal(expectedOutput, output);
    }
    
    // + and - operator loop the letter around
    [Theory]
    [InlineData('Z', 1, 'A')]
    public void LetterLoopWhenIncremented(char input, int increment, char expectedOutput)
    {
        var letter = new Letter(input);
        var outputLetter = letter + increment;
        char output = outputLetter.GetChar();
        
        Assert.Equal(expectedOutput, output);
    }
    [Theory]
    [InlineData('A', 1, 'Z')]
    public void LetterLoopWhenDecremented(char input, int decrement, char expectedOutput)
    {
        var letter = new Letter(input);
        var outputLetter = letter - decrement;
        char output = outputLetter.GetChar();
        
        Assert.Equal(expectedOutput, output);
    }
    
}