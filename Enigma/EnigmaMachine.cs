using System.Collections.Generic;

namespace Enigma;

public class EnigmaMachine
{
    private struct SignalComponent
    {
        private readonly Dictionary<char, char> _forwardMapping;
        private readonly Dictionary<char, char> _backwardMapping;

        public SignalComponent(string mappingString)
        {
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            _forwardMapping = new Dictionary<char, char>();
            _backwardMapping = new Dictionary<char, char>();

            for (int i = 0; i < alphabet.Length; i++)
            {
                _forwardMapping[alphabet[i]] = mappingString[i];
                _backwardMapping[mappingString[i]] = alphabet[i];
            }
        }

        public char GetForwardLetter(char letter)
        {
            return _forwardMapping[letter];
        }

        public char GetBackwardLetter(char letter)
        {
            return _backwardMapping[letter];
        }
    }

    private int _numberOfRotors;
    private SignalComponent[] _componentArray;


    public EnigmaMachine(int numberOfRotors = 3)
    {
        _numberOfRotors = numberOfRotors;
        
        // Number of components = numberOfRotors + reflector + plugboard
        _componentArray = new SignalComponent[_numberOfRotors + 2];
        
        InitializeEmptyMachine();
    }
    
    // Initializes all the components to always return the same letter
    private void InitializeEmptyMachine()
    {
        var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        // Initialize plugboard
        _componentArray[0] = new SignalComponent(alphabet);

        // Initialize rotors
        for (int i = 1; i <= _numberOfRotors; i++)
        {
            _componentArray[i] = new SignalComponent(alphabet);
        }
        
        // Initialize reflector
        _componentArray[_numberOfRotors + 1] = new SignalComponent(alphabet);
    }

    public string ExecuteMessage(string message)
    {
        string encryptedMessage = "";

        foreach (char letter in message)
        {
            if (letter == ' ')
            {
                encryptedMessage += letter;
                continue;
            }
            
            char encryptedLetter = letter;
            
            // Forward loop
            for (var i = 0; i < _componentArray.Length; i++)
            {
                encryptedLetter = _componentArray[i].GetForwardLetter(encryptedLetter);
            }

            // Backward loop (excluding reflector)
            for (int i = _componentArray.Length - 2; i >= 0; i--)
            {
                encryptedLetter = _componentArray[i].GetBackwardLetter(encryptedLetter);
            }

            encryptedMessage += encryptedLetter;
        }
        
        
        return encryptedMessage;
    }
}