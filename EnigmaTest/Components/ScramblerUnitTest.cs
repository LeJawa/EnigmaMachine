using Enigma.Components;
using Xunit;

namespace EnigmaTest.Components;

public class ScramblerUnitTest
{
    // Contains RotorAssembly and Reflector
    [Fact]
    public void TestScramblerUnitConstructor()
    {
        var unused = new ScramblerUnit("A", "III II I", "A A A", "A A A");
    }
    
    // Correct TopPosition after encoding once
    [Theory]
    [InlineData("A A A", "A A B")]
    [InlineData("A E A", "B F B")]
    public void TestTopPositionsAfterEncodingOnce(string startPositions, string expectedTopPositions)
    {
        ScramblerUnit scramblerUnit = new ScramblerUnit("B", "III II I", startPositions);

        scramblerUnit.Encode('A');
        string rotorTopPositions = scramblerUnit.RotorTopPositions;

        Assert.Equal(expectedTopPositions, rotorTopPositions);
    }
    // Correct TopPosition after encoding twice
    [Theory]
    [InlineData("A A A", "A A C")]
    [InlineData("A E A", "B F C")]
    [InlineData("A D Q", "B F S")]
    public void TestTopPositionsAfterEncodingTwice(string startPositions, string expectedTopPositions)
    {
        ScramblerUnit scramblerUnit = new ScramblerUnit("B", "III II I", startPositions);

        scramblerUnit.Encode('A');
        scramblerUnit.Encode('A');
        string rotorTopPositions = scramblerUnit.RotorTopPositions;

        Assert.Equal(expectedTopPositions, rotorTopPositions);
    }
    
    // Correct output
    [Theory]
    [InlineData("A A A", 'A', 'F')]
    [InlineData("A E A", 'A', 'J')]
    public void TestOutputAfterEncodingOnce(string startPositions, char input, char expectedOutput)
    {
        ScramblerUnit scramblerUnit = new ScramblerUnit("B", "III II I", startPositions);

        char encodedLetter = scramblerUnit.Encode(input);

        Assert.Equal(expectedOutput, encodedLetter);
    }
    
    // Test GetRotorsInfo
    [Fact]
    public void TestGetRotorsInfo()
    {
        ScramblerUnit scramblerUnit = new ScramblerUnit("B", "III II I", "A A A");

        Rotor.Info[] rotorsInfo = scramblerUnit.GetRotorsInfo();

        Assert.Equal(3, rotorsInfo.Length);
    }
    
    // Test GetReflectorInfo
    [Fact]
    public void GetReflectorInfo()
    {
        ScramblerUnit scramblerUnit = new ScramblerUnit("B", "III II I", "A A A");

        Reflector.Info reflectorInfo = scramblerUnit.GetReflectorInfo();

        Assert.IsType<Reflector.Info>(reflectorInfo);
    }
}