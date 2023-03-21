using System.Collections.Generic;

namespace Enigma;

public class EnigmaMachine
{
    private class SignalComponent
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
    
    private class Rotor: SignalComponent
    {
        private int _ringPosition = 0;
        private int _topPosition = 0;
        
        private int _notch1;
        private int _notch2;
        
        public Rotor(string mappingString, int notch1, int notch2 = -1) : base(mappingString)
        {
            _notch1 = notch1;
            _notch2 = notch2;
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

    public void InitializeReflector(char reflector)
    {
        // Reflector (mapping)  ABCDEFGHIJKLMNOPQRSTUVWXYZ
        // Reflector A 	        EJMZALYXVBWFCRQUONTSPIKHGD
        // Reflector B 	        YRUHQSLDPXNGOKMIEBFZCWVJAT
        // Reflector C 	        FVPJIAOYEDRZXWGCTKUQSBNMHL
        // Reflector B Thin 	ENKQAUYWJICOPBLMDXZVFTHRGS
        // Reflector C Thin 	RDOBJNTKVEHMLFCWZAXGYIPSUQ

        throw new System.NotImplementedException();
    }

    public void InitializePlugboard(string positions)
    {
        throw new System.NotImplementedException();
    }

    public void InitializeRotors(string rotors, string ringPositions, string startPositions)
    {
        // Rotor Mapping    ABCDEFGHIJKLMNOPQRSTUVWXYZ
        // I 	            EKMFLGDQVZNTOWYHXUSPAIBRCJ
        // II 	            AJDKSIRUXBLHWTMCQGZNPYFVOE
        // III 	            BDFHJLCPRTXVZNYEIWGAKMUSQO
        // IV 	            ESOVPZJAYQUIRHXLNFTGKDCMWB
        // V 	            VZBRGITYUPSDNHLXAWMJQOFECK
        // VI 	            JPGVOUMFYQBENHZRDKASXLICTW
        // VII 	            NZJHGRCXMYSWBOUFAIVLPEKQDT
        // VIII 	        FKQHTLXOCBJSPDZRAMEWNIUYGV
        // Beta 	        LEYJVCNIXWPBQMDRTAKZGFUHOS
        // Gamma 	        FSOKANUERHMBTIYCWLQPZXVGJD
        
        // Rotor 	        Notch 	Effect
        // I 	            Q 	    If rotor steps from Q to R, the next rotor is advanced
        // II 	            E 	    If rotor steps from E to F, the next rotor is advanced
        // III 	            V 	    If rotor steps from V to W, the next rotor is advanced
        // IV 	            J 	    If rotor steps from J to K, the next rotor is advanced
        // V 	            Z 	    If rotor steps from Z to A, the next rotor is advanced
        // VI, VII, VIII 	Z+M 	If rotor steps from Z to A, or from M to N the next rotor is advanced
        
        throw new System.NotImplementedException();
    }
}