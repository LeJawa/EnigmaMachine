using Enigma.Components;

namespace Enigma;

public class EnigmaMachine
{
    public struct Info
    {
        public PlugBoard.Info PlugboardInfo;
        public Reflector.Info ReflectorInfo;
        public Rotor.Info[] RotorInfoList;
    }

    private readonly PlugBoard _plugBoard;
    private readonly ScramblerUnit _scramblerUnit;

    public EnigmaMachine()
    {
        _plugBoard = new PlugBoard();
        _scramblerUnit = new ScramblerUnit();
    }
    
    public EnigmaMachine(string reflectorName, string rotorPositions, string rotorStartPositions, string rotorRingPositions, string plugBoardPairs)
    {
        _plugBoard = new PlugBoard(plugBoardPairs);
        _scramblerUnit = new ScramblerUnit(reflectorName, rotorPositions, rotorStartPositions, rotorRingPositions);
    }

    public string Decrypt(string encryptedMessage)
    {
        string decryptedMessage = "";
        
        foreach (char letter in encryptedMessage)
        {
            if (letter == ' ')
            {
                decryptedMessage += letter;
                continue;
            }

            char tmpLetter = _plugBoard.ForwardsPass(letter);
            tmpLetter = _scramblerUnit.Encode(tmpLetter);
            char decryptedLetter = _plugBoard.BackwardsPass(tmpLetter);

            decryptedMessage += decryptedLetter;
        }

        return decryptedMessage;
    }

    public string Encrypt(string clearMessage)
    {
        return Decrypt(clearMessage);
    }

    public Info GetInfo()
    {
        var info = new Info
        {
            PlugboardInfo = _plugBoard.GetInfo(),
            ReflectorInfo = _scramblerUnit.GetReflectorInfo(),
            RotorInfoList = _scramblerUnit.GetRotorsInfo()
        };
        return info;
    }
}