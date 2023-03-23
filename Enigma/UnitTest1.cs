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
    public void TestEmptyMachineWithReflectors()
    {
        EnigmaMachine machine = new EnigmaMachine();
        machine.InitializeReflector('A');
        
        var message = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        var encryptedMessage = machine.ExecuteMessage(message);
        
        Assert.True(encryptedMessage == "EJMZALYXVBWFCRQUONTSPIKHGD");
        
        machine.InitializeReflector('B');

        encryptedMessage = machine.ExecuteMessage(message);
        
        Assert.True(encryptedMessage == "YRUHQSLDPXNGOKMIEBFZCWVJAT");
        
        machine.InitializeReflector('C');

        encryptedMessage = machine.ExecuteMessage(message);
        
        Assert.True(encryptedMessage == "FVPJIAOYEDRZXWGCTKUQSBNMHL");
        
        machine.InitializeReflector('b');

        encryptedMessage = machine.ExecuteMessage(message);
        
        Assert.True(encryptedMessage == "ENKQAUYWJICOPBLMDXZVFTHRGS");
        
        machine.InitializeReflector('c');

        encryptedMessage = machine.ExecuteMessage(message);
        
        Assert.True(encryptedMessage == "RDOBJNTKVEHMLFCWZAXGYIPSUQ");
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
        machine.InitializeRotors("I II III IV V VI VII VIII Beta Gamma", "", "");
        
        var message = "THIS IS A MESSAGE";

        var encryptedMessage = machine.ExecuteMessage(message);
        
        Assert.True(encryptedMessage == "THIS IS A MESSAGE", encryptedMessage);
    }
}