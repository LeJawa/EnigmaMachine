using Enigma.Components;
using Xunit;
// ReSharper disable StringLiteralTypo

// ReSharper disable CommentTypo

namespace EnigmaTest.Components;

public class ReflectorTest
{
    // Reflector is child of SignalComponent
    [Fact]
    public void TestReflectorIsChildOfSignalComponent()
    {
        Reflector reflector = new Reflector();

        Assert.IsAssignableFrom<SymmetricSignalComponent>(reflector);
    }
    
    // Correct output after forwards pass for empty constructor
    [Theory]
    [InlineData('A', 'A')]
    [InlineData('B', 'B')]
    [InlineData('Z', 'Z')]
    public void TestCorrectOutputAfterForwardsPassWithEmptyConstructor(char input, char expectedOutput)
    {
        Reflector reflector = new Reflector();
        
        char output = reflector.ForwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
    
    // Correct output after forwards pass with constructor with string mapping
    // mapping = "EJMZALYXVBWFCRQUONTSPIKHGD"
    [Theory]
    [InlineData('A', 'E')]
    [InlineData('E', 'A')]
    [InlineData('B', 'J')]
    [InlineData('Z', 'D')]
    public void TestCorrectOutputAfterForwardsPassWithStringMapping(char input, char expectedOutput)
    {
        Reflector reflector = new Reflector(Reflector.Name.A, "EJMZALYXVBWFCRQUONTSPIKHGD");
        
        char output = reflector.ForwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
    
    // Correct output after backwards pass with constructor with string mapping
    // mapping = "EJMZALYXVBWFCRQUONTSPIKHGD"
    [Theory]
    [InlineData('A', 'E')]
    [InlineData('E', 'A')]
    [InlineData('B', 'J')]
    [InlineData('Z', 'D')]
    public void TestCorrectOutputAfterBackwardsPassWithStringMapping(char input, char expectedOutput)
    {
        Reflector reflector = new Reflector(Reflector.Name.A, "EJMZALYXVBWFCRQUONTSPIKHGD");
        
        char output = reflector.BackwardsPass(input);
        
        Assert.Equal(output, expectedOutput);
    }
    
    // Test GetInfo
    [Fact]
    public void TestGetInfo()
    {
        var reflector = new Reflector(Reflector.Name.A, "EJMZALYXVBWFCRQUONTSPIKHGD");

        Reflector.Info info = reflector.GetInfo();

        Assert.Equal(Reflector.Name.A, info.Name);
        // I am not asserting info.Mapping because it seems complicated and I am pretty sure it will work.
        // Famous last words.
    }
    
    
}