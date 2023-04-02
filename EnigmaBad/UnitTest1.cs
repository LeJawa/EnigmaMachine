using Xunit;

namespace EnigmaBad;

public class UnitTest1
{
    [Fact]
    public void TestEmptyMachine()
    {
        var machine = new EnigmaMachine();

        const string message = "THIS IS A MESSAGE";

        string encryptedMessage = machine.ExecuteMessage(message);

        Assert.True(message == encryptedMessage, "Empty machine does not work.");
    }

    [Fact]
    public void TestEmptyMachineWithReflectors()
    {
        var machine = new EnigmaMachine();
        machine.InitializeReflector('A');

        const string message = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        string encryptedMessage = machine.ExecuteMessage(message);

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
        var machine = new EnigmaMachine();
        machine.InitializePlugboard("AM FI NV PS TU WZ");

        const string message = "THIS IS A MESSAGE";

        string encryptedMessage = machine.ExecuteMessage(message);

        Assert.True(encryptedMessage == "THIS IS A MESSAGE", encryptedMessage);
    }

    [Fact]
    public void TestMachineWithRotors()
    {
        var machine = new EnigmaMachine();
        machine.InitializeRotors("I II III IV V VI VII VIII Beta Gamma", "1 1 1 1 1 1 1 1 1 1", "A A A A A A A A A A");

        const string message = "THIS IS A MESSAGE";

        string encryptedMessage = machine.ExecuteMessage(message);

        Assert.True(encryptedMessage == "THIS IS A MESSAGE", encryptedMessage);
    }

    [Fact]
    public void TestEnigmaInstructionManual1930()
    {
        var machine = new EnigmaMachine();
        machine.InitializeReflector('A');
        machine.InitializeRotors("II I III", "24 13 22", "A B L");
        machine.InitializePlugboard("AM FI NV PS TU WZ");
        
        const string message = 
            "GCDSE AHUGW TQGRK VLFGX UCALX VYMIG MMNMF DXTGN VHVRM MEVOU YFZSL RHDRR XFJWC FHUHM UNZEF RDISI KBGPM YVXUZ";
        const string decryptedMessage =
            "FEIND LIQEI NFANT ERIEK OLONN EBEOB AQTET XANFA NGSUE DAUSG ANGBA ERWAL DEXEN DEDRE IKMOS TWAER TSNEU STADT";
        
        string encryptedMessage = machine.ExecuteMessage(message);
        
        
        Assert.True(encryptedMessage == decryptedMessage, encryptedMessage);
    }
    
    
    [Fact]
    public void TestEnigma1Rotor()
    {
        var machine = new EnigmaMachine();
        machine.InitializeRotors("I", "3", "A");
        machine.InitializePlugboard("");
        
        const string message = 
            "GCDSE AHUGW TQGRK VLFGX UCALX VYMIG MMNMF DXTGN VHVRM MEVOU YFZSL RHDRR XFJWC FHUHM UNZEF RDISI KBGPM YVXUZ";
        const string decryptedMessage =
            "GCDSE AHUGW TQGRK VLFGX UCALX VYMIG MMNMF DXTGN VHVRM MEVOU YFZSL RHDRR XFJWC FHUHM UNZEF RDISI KBGPM YVXUZ";
        
        string encryptedMessage = machine.ExecuteMessage(message);
        
        
        Assert.True(encryptedMessage == decryptedMessage, encryptedMessage);
    }
}