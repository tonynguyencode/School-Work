using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Character_Frequency
{
    public class CharacterFrequency
    {
        private char _character;
        private int _frequency;

        public CharacterFrequency()
        {
            this._character = '\x0000';
            this._frequency = 1;
        }


        public CharacterFrequency(char character)
        {
            this._character = character;
            this._frequency = 1;
        }

        public CharacterFrequency(CharacterFrequency character)
        {
            this._character = character._character;
            this._frequency = character._frequency;
        }

        public char Character
        {
            get { return this._character; }
            set { this._character = value; }
        }

        public int Frequency
        {
            get { return this._frequency; }
            set { this._frequency = value; }
        }
        public void Increment()
        {
            this._frequency += 1;
        }
        public override int GetHashCode()
        {
            return (int)_frequency;
        }
        public override string ToString()
        {
            return $"{this._character} ({(int)_character})      Frequency: {this._frequency}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            if (obj == this) { return true; }

            //Cast obj to a student. If the cast cannot be performed, student variable will be set to null
            CharacterFrequency variable = obj as CharacterFrequency;

            if (variable == null)
            {
                return false;
            }
            return _character.Equals(variable._character);
        }
        static void Main()
        {
            
        }
    }
}
