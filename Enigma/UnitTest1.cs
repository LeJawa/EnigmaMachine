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

    [Fact]
    public void TestEmptyMachineWithReflectorA()
    {
        EnigmaMachine machine = new EnigmaMachine();
        machine.InitializeReflector('A');
        
        var message = "THIS IS A MESSAGE";

        var encryptedMessage = machine.ExecuteMessage(message);
        
        Assert.True(encryptedMessage == "SXVT VT E CATTEYA");
    }

    [Fact]
    public void TestEmptyMachineWithPlugboard()
    {
        EnigmaMachine machine = new EnigmaMachine();
        machine.InitializePlugboard("AM FI NV PS TU WZ");
        
        var message = "THIS IS A MESSAGE";

        var encryptedMessage = machine.ExecuteMessage(message);
        
        Assert.True(encryptedMessage == "THIS IS A MESSAGE", encryptedMessage);

    }

    [Fact]
    public void TestMachineWith3Rotors()
    {
        EnigmaMachine machine = new EnigmaMachine();
        machine.InitializeRotors("II IV V", "", "");
        
        var message = "THIS IS A MESSAGE";

        var encryptedMessage = machine.ExecuteMessage(message);
        
        Assert.True(encryptedMessage == "THIS IS A MESSAGE", encryptedMessage);
    }
}