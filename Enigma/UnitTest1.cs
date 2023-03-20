using Xunit;

namespace Enigma;

public class UnitTest1
{
    [Fact]
    public void TestEmptyMachine()
    {
        EnigmaMachine machine = new EnigmaMachine();
        
        var message = "THIS IS A MESSAGE";

        var encryptedMessage = machine.ExecuteMessage(message);
        
        Assert.True(message == encryptedMessage, "Empty machine does not work.");
    }
}