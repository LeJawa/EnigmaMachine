using System;
using Enigma.Components;
using Xunit;

// ReSharper disable CommentTypo

namespace EnigmaTest.Components;

public class PlugBoardTest
{
    // PlugBoard is child of SignalComponent
    [Fact]
    public void TestPlugBoardIsChildOfSignalComponent()
    {
        PlugBoard plugBoard = new PlugBoard();

        Assert.IsAssignableFrom<SymmetricSignalComponent>(plugBoard);
    }
    
    // Plugboard has special letter-pairs constructor
    [Fact]
    public void TestPlugBoardLetterPairConstructor()
    {
        PlugBoard plugBoard = new PlugBoard("AB FR");
        
        Assert.NotNull(plugBoard);
    }
    
    // Plugboard constructor throws ArgmumentException if no letter-pairs in input string
    [Theory]
    [InlineData("ABC")]
    [InlineData("A")]
    [InlineData("AB CDE")]
    [InlineData("AB C")]
    public void TestConstructorThrowsArgumentExceptionForNonLetterPairs(string letterPairs)
    {
        var exception = Record.Exception(() => new PlugBoard(letterPairs));

        Assert.NotNull(exception);
        Assert.IsType<ArgumentException>(exception);
        Assert.Equal(exception.Message, PlugBoard.ErrorMessages.FoundNonPairsInString(letterPairs));
    }
    
    // Plugboard constructor throws ArgmumentException if no-letter found in input string
    [Theory]
    [InlineData(".")]
    [InlineData("AB.")]
    public void TestConstructorThrowsArgumentExceptionIfNonLetterFound(string letterPairs)
    {
        var exception = Record.Exception(() => new PlugBoard(letterPairs));

        Assert.NotNull(exception);
        Assert.IsType<ArgumentException>(exception);
        Assert.Equal(exception.Message, PlugBoard.ErrorMessages.FoundIncorrectCharactersInString(letterPairs));
    }
    
    // Letters cannot be duplicated in constructor input => constructor throws ArgumentException
    [Theory]
    [InlineData("AA")]
    [InlineData("AB CA")]
    public void TestConstructorThrowsArgumentExceptionIfRepeatedLetterFound(string letterPairs)
    {
        var exception = Record.Exception(() => new PlugBoard(letterPairs));

        Assert.NotNull(exception);
        Assert.IsType<ArgumentException>(exception);
        Assert.Equal(exception.Message, PlugBoard.ErrorMessages.FoundRepeatedLetterInString(letterPairs));
    }
    
    // There cannot be more than 10 letter-pairs
    [Theory]
    [InlineData("AB CD EF GH IJ KL MN OP QR ST UV")]
    public void TestConstructorThrowsArgumentExceptionIfMoreThanTenPairs(string letterPairs)
    {
        var exception = Record.Exception(() => new PlugBoard(letterPairs));

        Assert.NotNull(exception);
        Assert.IsType<ArgumentException>(exception);
        Assert.Equal(exception.Message, PlugBoard.ErrorMessages.FoundMoreThanTenPairsInString(letterPairs));
    }
    
    // Correct output after forwards pass for empty constructor
    [Theory]
    [InlineData('A', 'A')]
    [InlineData('B', 'B')]
    [InlineData('Z', 'Z')]
    public void TestCorrectOutputAfterForwardsPassWithEmptyConstructor(char input, char expectedOutput)
    {
        PlugBoard plugBoard = new PlugBoard();
        
        char output = plugBoard.ForwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
    
    // Correct output after forwards pass for one letter pair
    [Theory]
    [InlineData("AB", 'A', 'B')]
    [InlineData("AB", 'B', 'A')]
    [InlineData("AB", 'Z', 'Z')]
    public void TestCorrectOutputAfterForwardsPassConstructorOnePair(string letterPairs, char input, char expectedOutput)
    {
        PlugBoard plugBoard = new PlugBoard(letterPairs);
        
        char output = plugBoard.ForwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
    
    // Correct output after backwards pass for one letter pair
    [Theory]
    [InlineData("AB", 'B', 'A')]
    [InlineData("AB", 'A', 'B')]
    [InlineData("AB", 'Z', 'Z')]
    public void TestCorrectOutputAfterBackwardsPassConstructorOnePair(string letterPairs, char input, char expectedOutput)
    {
        PlugBoard plugBoard = new PlugBoard(letterPairs);
        
        char output = plugBoard.BackwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
    
    // Correct output after forwards pass for multiple letter pair
    [Theory]
    [InlineData("AB CD", 'B', 'A')]
    [InlineData("AB CD", 'D', 'C')]
    [InlineData("AB CD", 'Z', 'Z')]
    public void TestCorrectOutputAfterForwardsPassConstructorMultiplePairs(string letterPairs, char input, char expectedOutput)
    {
        PlugBoard plugBoard = new PlugBoard(letterPairs);
        
        char output = plugBoard.ForwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
    
    // Correct output after backwards pass for multiple letter pair
    [Theory]
    [InlineData("AB CD", 'B', 'A')]
    [InlineData("AB CD", 'D', 'C')]
    [InlineData("AB CD", 'Z', 'Z')]
    public void TestCorrectOutputAfterBackwardsPassConstructorMultiplePairs(string letterPairs, char input, char expectedOutput)
    {
        PlugBoard plugBoard = new PlugBoard(letterPairs);
        
        char output = plugBoard.BackwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
}