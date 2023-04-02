using Enigma;
using Xunit;
// ReSharper disable StringLiteralTypo

namespace EnigmaTest;

public class EnigmaMachineTest
{
    // Constructor works
    [Fact]
    public void TestEnigmaMachineConstructor()
    {
        EnigmaMachine enigmaMachine = new EnigmaMachine("A", "III II I", "A A A", "A A A", "AB");
    }
    
    // Decrypt Strings
    [Fact]
    public void TestDecryptionOfShortString()
    {
        EnigmaMachine enigmaMachine = new EnigmaMachine(
            "A",
            "II I III",
            "A B L",
            "X M V",
            "AM FI NV PS TU WZ");
        
        string encryptedMessage = "GCDSE AHUGW";
        string expectedDecryptedMessage = "FEIND LIQEI";

        var decryptedMessage = enigmaMachine.Decrypt(encryptedMessage);
        
        Assert.Equal(expectedDecryptedMessage, decryptedMessage);
    }
    
    [Fact]
    public void TestDecryptionOfLongString()
    {
        EnigmaMachine enigmaMachine = new EnigmaMachine(
            "A",
            "II I III",
            "A B L",
            "X M V",
            "AM FI NV PS TU WZ");
        
        string encryptedMessage = "GCDSE AHUGW TQGRK VLFGX UCALX VYMIG MMNMF DXTGN VHVRM MEVOU YFZSL RHDRR XFJWC FHUHM UNZEF RDISI KBGPM YVXUZ";
        string expectedDecryptedMessage = "FEIND LIQEI NFANT ERIEK OLONN EBEOB AQTET XANFA NGSUE DAUSG ANGBA ERWAL DEXEN DEDRE IKMOS TWAER TSNEU STADT";

        var decryptedMessage = enigmaMachine.Decrypt(encryptedMessage);
        
        Assert.Equal(expectedDecryptedMessage, decryptedMessage);
    }
    
    
    // Encrypt Strings
    [Fact]
    public void TestEncryptionOfShortString()
    {
        EnigmaMachine enigmaMachine = new EnigmaMachine(
            "A",
            "II I III",
            "A B L",
            "X M V",
            "AM FI NV PS TU WZ");
        
        string clearMessage = "FEIND LIQEI";
        string expectedEncryptedMessage = "GCDSE AHUGW";

        var encryptedMessage = enigmaMachine.Encrypt(clearMessage);
        
        Assert.Equal(expectedEncryptedMessage, encryptedMessage);
    }
    
    [Fact]
    public void TestEncryptionOfLongString()
    {
        EnigmaMachine enigmaMachine = new EnigmaMachine(
            "A",
            "II I III",
            "A B L",
            "X M V",
            "AM FI NV PS TU WZ");
        
        string expectedEncryptedMessage = "GCDSE AHUGW TQGRK VLFGX UCALX VYMIG MMNMF DXTGN VHVRM MEVOU YFZSL RHDRR XFJWC FHUHM UNZEF RDISI KBGPM YVXUZ";
        string clearMessage = "FEIND LIQEI NFANT ERIEK OLONN EBEOB AQTET XANFA NGSUE DAUSG ANGBA ERWAL DEXEN DEDRE IKMOS TWAER TSNEU STADT";

        var encryptedMessage = enigmaMachine.Encrypt(clearMessage);
        
        Assert.Equal(expectedEncryptedMessage, encryptedMessage);
    }
    
}