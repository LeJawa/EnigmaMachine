using System.Collections.Generic;

// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo

namespace Enigma;

public class EnigmaMachine
{
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    private class SignalComponent
    {
        private readonly Dictionary<char, char> _forwardMapping;
        private readonly Dictionary<char, char> _backwardMapping;

        public SignalComponent(string mappingString = Alphabet)
        {
            _forwardMapping = new Dictionary<char, char>();
            _backwardMapping = new Dictionary<char, char>();

            for (int i = 0; i < Alphabet.Length; i++)
            {
                _forwardMapping[Alphabet[i]] = mappingString[i];
                _backwardMapping[mappingString[i]] = Alphabet[i];
            }
        }

        public void SetLetter(char letter1, char letter2)
        {
            _forwardMapping[letter1] = letter2;
            _forwardMapping[letter2] = letter1;
            _backwardMapping[letter2] = letter1;
            _backwardMapping[letter1] = letter2;
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

    private class Rotor : SignalComponent
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

        public Rotor() : base()
        {
            _notch1 = -1;
            _notch2 = -1;
        }
    }

    private class ScramblerUnit
    {
        private SignalComponent _reflector;
        private Rotor[] _rotors;

        public int NumberOfRotors => _rotors.Length;

        public ScramblerUnit()
        {
            _reflector = new SignalComponent();
            _rotors = new Rotor[] { new() };
        }

        public void InitializeReflector(char reflector)
        {
            // Reflector (mapping)  ABCDEFGHIJKLMNOPQRSTUVWXYZ
            // Reflector A 	        EJMZALYXVBWFCRQUONTSPIKHGD
            // Reflector B 	        YRUHQSLDPXNGOKMIEBFZCWVJAT
            // Reflector C 	        FVPJIAOYEDRZXWGCTKUQSBNMHL
            // Reflector B Thin (b)	ENKQAUYWJICOPBLMDXZVFTHRGS
            // Reflector C Thin (c)	RDOBJNTKVEHMLFCWZAXGYIPSUQ

            switch (reflector)
            {
                case 'A': //       ABCDEFGHIJKLMNOPQRSTUVWXYZ
                    _reflector = new SignalComponent("EJMZALYXVBWFCRQUONTSPIKHGD");
                    return;
                case 'B':
                    _reflector = new SignalComponent("YRUHQSLDPXNGOKMIEBFZCWVJAT");
                    return;
                case 'C':
                    _reflector = new SignalComponent("FVPJIAOYEDRZXWGCTKUQSBNMHL");
                    return;
                case 'b':
                    _reflector = new SignalComponent("ENKQAUYWJICOPBLMDXZVFTHRGS");
                    return;
                case 'c':
                    _reflector = new SignalComponent("RDOBJNTKVEHMLFCWZAXGYIPSUQ");
                    return;
            }
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

            var rotorStringArray = rotors.Split(' ');

            _rotors = new Rotor[rotorStringArray.Length];

            for (var i = 0; i < rotorStringArray.Length; i++)
            {
                switch (rotorStringArray[i])
                {
                    case "I": //       ABCDEFGHIJKLMNOPQRSTUVWXYZ
                        _rotors[i] = new Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'Q');
                        break;
                    case "II": //       ABCDEFGHIJKLMNOPQRSTUVWXYZ
                        _rotors[i] = new Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE", 'E');
                        break;
                    case "III": //       ABCDEFGHIJKLMNOPQRSTUVWXYZ
                        _rotors[i] = new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO", 'V');
                        break;
                    case "IV": //       ABCDEFGHIJKLMNOPQRSTUVWXYZ
                        _rotors[i] = new Rotor("ESOVPZJAYQUIRHXLNFTGKDCMWB", 'J');
                        break;
                    case "V": //       ABCDEFGHIJKLMNOPQRSTUVWXYZ
                        _rotors[i] = new Rotor("VZBRGITYUPSDNHLXAWMJQOFECK", 'Z');
                        break;
                    case "VI": //       ABCDEFGHIJKLMNOPQRSTUVWXYZ
                        _rotors[i] = new Rotor("JPGVOUMFYQBENHZRDKASXLICTW", 'Z', 'M');
                        break;
                    case "VII": //       ABCDEFGHIJKLMNOPQRSTUVWXYZ
                        _rotors[i] = new Rotor("NZJHGRCXMYSWBOUFAIVLPEKQDT", 'Z', 'M');
                        break;
                    case "VIII": //       ABCDEFGHIJKLMNOPQRSTUVWXYZ
                        _rotors[i] = new Rotor("FKQHTLXOCBJSPDZRAMEWNIUYGV", 'Z', 'M');
                        break;
                    case "Beta": //       ABCDEFGHIJKLMNOPQRSTUVWXYZ
                        _rotors[i] = new Rotor("LEYJVCNIXWPBQMDRTAKZGFUHOS", -1);
                        break;
                    case "Gamma": //       ABCDEFGHIJKLMNOPQRSTUVWXYZ
                        _rotors[i] = new Rotor("FSOKANUERHMBTIYCWLQPZXVGJD", -1);
                        break;
                }
            }
        }

        public char GetLetter(char letter)
        {
            var encryptedLetter = letter;

            foreach (Rotor rotor in _rotors)
            {
                encryptedLetter = rotor.GetForwardLetter(encryptedLetter);
            }

            encryptedLetter = _reflector.GetForwardLetter(encryptedLetter);

            // Backward loop (excluding reflector)
            for (int i = NumberOfRotors - 1; i >= 0; i--)
            {
                encryptedLetter = _rotors[i].GetBackwardLetter(encryptedLetter);
            }

            return encryptedLetter;
        }
    }

    private SignalComponent _plugboard;

    private ScramblerUnit _scramblerUnit;

    public EnigmaMachine()
    {
        _scramblerUnit = new ScramblerUnit();
        _plugboard = new SignalComponent();
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
            encryptedLetter = _plugboard.GetForwardLetter(encryptedLetter);

            encryptedLetter = _scramblerUnit.GetLetter(encryptedLetter);

            encryptedLetter = _plugboard.GetBackwardLetter(encryptedLetter);

            encryptedMessage += encryptedLetter;
        }


        return encryptedMessage;
    }


    public void InitializePlugboard(string positions)
    {
        foreach (var pair in positions.Split(' '))
        {
            _plugboard.SetLetter(pair[0], pair[1]);
        }
    }

    public void InitializeReflector(char reflector)
    {
        _scramblerUnit.InitializeReflector(reflector);
    }

    public void InitializeRotors(string rotors, string ringPositions, string startPositions)
    {
        _scramblerUnit.InitializeRotors(rotors, ringPositions, startPositions);
    }
}