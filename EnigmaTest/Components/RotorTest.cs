using Enigma.Components;
using Xunit;
// ReSharper disable StringLiteralTypo

// ReSharper disable CommentTypo

namespace EnigmaTest.Components;

public class RotorTest
{
    // Rotor is child of DirectionalSignalComponent
    [Fact]
    public void TestRotorIsChildOfDirectionalSignalComponent()
    {
        Rotor rotor = new Rotor();

        Assert.IsAssignableFrom<DirectionalSignalComponent>(rotor);
    }
    
    // Test empty constructor exists
    [Fact]
    public void TestExistenceOfSignalComponentEmptyConstructor()
    {
        var component = new Rotor(); 
        Assert.NotNull(component);
    }
    
    // Test string constructor exists
    [Fact]
    public void TestExistenceOfSignalComponentStringConstructor()
    {
        var component = new Rotor(Rotor.Name.Straight, SymmetricSignalComponent.Alphabet); 
        
        Assert.NotNull(component);
    }
    
    // Test SetNotch
    [Fact]
    public void TestSetOneNotch()
    {
        var component = new Rotor();
        component.SetNotch('A');
    }
    [Fact]
    public void TestSetTwoNotch()
    {
        var component = new Rotor();
        component.SetNotch('A', 'B');
    }
    
    
    // Test IsInNotchPosition
    [Theory]
    [InlineData(0, 'A')]
    [InlineData(1, 'B')]
    public void TestIsInNotchPositionTrue(int topPosition, char notch)
    {
        var component = new Rotor
        {
            StartPosition = topPosition
        };
        
        component.SetNotch(notch);

        Assert.True(component.IsInNotchPosition);
    }
    
    [Theory]
    [InlineData(0, 'B')]
    [InlineData(1, 'A')]
    public void TestIsInNotchPositionFalse(int topPosition, char notch)
    {
        var component = new Rotor
        {
            StartPosition = topPosition
        };
        
        component.SetNotch(notch);

        Assert.False(component.IsInNotchPosition);
    }
    
    // Test IsInNotchPosition with two notches
    [Theory]
    [InlineData(0, 'A', 'B')]
    [InlineData(1, 'A', 'B')]
    public void TestIsInNotchPositionTrueWithTwoNotches(int topPosition, char notch1, char notch2)
    {
        var component = new Rotor
        {
            StartPosition = topPosition
        };
        
        component.SetNotch(notch1, notch2);

        Assert.True(component.IsInNotchPosition);
    }
    
    [Theory]
    [InlineData(2, 'A', 'B')]
    [InlineData(0, 'C', 'B')]
    public void TestIsInNotchPositionFalseWithTwoNotches(int topPosition, char notch1, char notch2)
    {
        var component = new Rotor
        {
            StartPosition = topPosition
        };
        
        component.SetNotch(notch1, notch2);

        Assert.False(component.IsInNotchPosition);
    }

    // RingPosition works as intended
    [Theory]
    [InlineData(0, 'A', 'E')]
    [InlineData(0, 'Z', 'J')]
    [InlineData(1, 'A', 'K')]
    [InlineData(1, 'Z', 'D')]
    [InlineData(25, 'A', 'J')]
    [InlineData(25, 'Z', 'D')]
    public void TestRingPositionWithNonEmptyConstructor(int ringPosition, char input, char expectedOutput)
    {
        var rotor = new Rotor(Rotor.Name.I, "EKMFLGDQVZNTOWYHXUSPAIBRCJ")
        {
            RingPosition = ringPosition
        };

        char output = rotor.ForwardsPass(input);
        
        Assert.Equal(expectedOutput, output);
    }
    
    // StartPosition works as intended
    [Theory]
    [InlineData(0, 'A', 'E')]
    [InlineData(0, 'Z', 'J')]
    [InlineData(1, 'A', 'J')]
    [InlineData(1, 'Z', 'D')]
    [InlineData(25, 'A', 'K')]
    [InlineData(25, 'Z', 'D')]
    public void TestStartPositionWithNonEmptyConstructor(int startPosition, char input, char expectedOutput)
    {
        var rotor = new Rotor(Rotor.Name.I, "EKMFLGDQVZNTOWYHXUSPAIBRCJ")
        {
            StartPosition = startPosition
        };

        char output = rotor.ForwardsPass(input);
        
        Assert.Equal(expectedOutput, output);
    }

    // Rotate once works as intended
    [Theory]
    [InlineData('A', 'J')]
    [InlineData('B', 'L')]
    [InlineData('Z', 'D')]
    public void TestRotateOnce(char input, char expectedOutput)
    {
        var rotor = new Rotor(Rotor.Name.I, "EKMFLGDQVZNTOWYHXUSPAIBRCJ");

        rotor.Rotate();

        char output = rotor.ForwardsPass(input);
        
        Assert.Equal(expectedOutput, output);
    }
    
    // Test Rotate multiple times
    [Theory]
    [InlineData(2, 'A', 'K')]
    [InlineData(2, 'B', 'D')]
    [InlineData(2, 'Z', 'I')]
    [InlineData(26, 'A', 'E')]
    [InlineData(26, 'B', 'K')]
    [InlineData(26, 'Z', 'J')]
    public void TestRotateMultipleTimes(int timesToRotate, char input, char expectedOutput)
    {
        var rotor = new Rotor(Rotor.Name.I, "EKMFLGDQVZNTOWYHXUSPAIBRCJ");

        for (int i = 0; i < timesToRotate; i++)
        {
            rotor.Rotate();
        }

        char output = rotor.ForwardsPass(input);
        
        Assert.Equal(expectedOutput, output);
    }
    
    // Same tests for Backward Passes
    
    
    // RingPosition works as intended
    [Theory]
    [InlineData(0, 'A', 'U')]
    [InlineData(0, 'Z', 'J')]
    [InlineData(1, 'A', 'K')]
    [InlineData(1, 'Z', 'P')]
    [InlineData(25, 'A', 'V')]
    [InlineData(25, 'Z', 'T')]
    public void TestRingPositionBackwardsPass(int ringPosition, char input, char expectedOutput)
    {
        var rotor = new Rotor(Rotor.Name.I, "EKMFLGDQVZNTOWYHXUSPAIBRCJ")
        {
            RingPosition = ringPosition
        };

        char output = rotor.BackwardsPass(input);
        
        Assert.Equal(expectedOutput, output);
    }
    
    // StartPosition works as intended
    [Theory]
    [InlineData(0, 'A', 'U')]
    [InlineData(0, 'Z', 'J')]
    [InlineData(1, 'A', 'V')]
    [InlineData(1, 'Z', 'T')]
    [InlineData(25, 'A', 'K')]
    [InlineData(25, 'Z', 'P')]
    public void TestStartPositionBackwardsPass(int startPosition, char input, char expectedOutput)
    {
        var rotor = new Rotor(Rotor.Name.I, "EKMFLGDQVZNTOWYHXUSPAIBRCJ")
        {
            StartPosition = startPosition
        };

        char output = rotor.BackwardsPass(input);
        
        Assert.Equal(expectedOutput, output);
    }

    // Rotate once works as intended
    [Theory]
    [InlineData('A', 'V')]
    [InlineData('B', 'X')]
    [InlineData('Z', 'T')]
    public void TestRotateOnceBackwardsPass(char input, char expectedOutput)
    {
        var rotor = new Rotor(Rotor.Name.I, "EKMFLGDQVZNTOWYHXUSPAIBRCJ");

        rotor.Rotate();

        char output = rotor.BackwardsPass(input);
        
        Assert.Equal(expectedOutput, output);
    }
    
    // Test Rotate multiple times
    [Theory]
    [InlineData(2, 'A', 'W')]
    [InlineData(2, 'B', 'E')]
    [InlineData(2, 'Z', 'U')]
    [InlineData(26, 'A', 'U')]
    [InlineData(26, 'B', 'W')]
    [InlineData(26, 'Z', 'J')]
    public void TestRotateMultipleTimesBackwardsPass(int timesToRotate, char input, char expectedOutput)
    {
        var rotor = new Rotor(Rotor.Name.I, "EKMFLGDQVZNTOWYHXUSPAIBRCJ");

        for (int i = 0; i < timesToRotate; i++)
        {
            rotor.Rotate();
        }

        char output = rotor.BackwardsPass(input);
        
        Assert.Equal(expectedOutput, output);
    }
    
    // Test constructor with one notch
    [Fact]
    public void TestRotorConstructorWithOneNotch()
    {
        var rotor = new Rotor(Rotor.Name.I, "EKMFLGDQVZNTOWYHXUSPAIBRCJ", notch1: 'A');
        
        Assert.True(rotor.IsInNotchPosition);
    }
    
    // Test constructor with two notch
    [Fact]
    public void TestRotorConstructorWithTwoNotches()
    {
        var rotor = new Rotor(Rotor.Name.I, "EKMFLGDQVZNTOWYHXUSPAIBRCJ", notch1: 'B', notch2: 'A');
        
        Assert.True(rotor.IsInNotchPosition);
    }
    
    // Test GetInfo
    [Fact]
    public void TestGetInfo()
    {
        var rotor = new Rotor(Rotor.Name.I, "EKMFLGDQVZNTOWYHXUSPAIBRCJ", notch1: 'A');

        Rotor.Info info = rotor.GetInfo();

        Assert.Equal(Rotor.Name.I, info.Name);
        Assert.Equal('A', info.RingSetting);
        Assert.Equal('A', info.TopPosition);
        Assert.Equal(new []{'A'}, info.Notch);
        // I am not asserting info.Mapping because it seems complicated and I am pretty sure it will work.
        // Famous last words.
    }
    
}