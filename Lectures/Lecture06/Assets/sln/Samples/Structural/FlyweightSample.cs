using System;
using System.Collections.Generic;

namespace Samples.Structural
{
    public class FlyweightSample
    {
        private static void Main()
        {
            // Build a document with text
            var document = "AAZZBBZB";
            var chars = document.ToCharArray();

            var factory = new CharacterFactory();

            // extrinsic state
            var pointSize = 10;

            // For each character use a flyweight object
            foreach (var c in chars)
            {
                pointSize++;
                var character = factory.GetCharacter(c);
                character.Display(pointSize);
            }
        }
    }

    internal class CharacterFactory
    {
        private readonly Dictionary<char, Character> characters =
            new Dictionary<char, Character>();

        public Character GetCharacter(char key)
        {
            // Uses "lazy initialization"
            Character character = null;
            if (characters.ContainsKey(key))
            {
                character = characters[key];
            }
            else
            {
                switch (key)
                {
                    case 'A':
                        character = new CharacterA();
                        break;
                    case 'B':
                        character = new CharacterB();
                        break;
                    //...

                    case 'Z':
                        character = new CharacterZ();
                        break;
                }

                characters.Add(key, character);
            }

            return character;
        }
    }

    internal abstract class Character
    {
        protected int ascent;
        protected int descent;
        protected int height;
        protected int pointSize;
        protected char symbol;
        protected int width;

        public abstract void Display(int pointSize);
    }

    internal class CharacterA : Character
    {
        public CharacterA()
        {
            symbol = 'A';
            height = 100;
            width = 120;
            ascent = 70;
            descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine($"{symbol} (pointsize {this.pointSize})");
        }
    }

    internal class CharacterB : Character
    {
        public CharacterB()
        {
            symbol = 'B';
            height = 100;
            width = 140;
            ascent = 72;
            descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine($"{symbol} (pointsize {this.pointSize})");
        }
    }

    // ... C, D, E, etc.

    internal class CharacterZ : Character
    {
        public CharacterZ()
        {
            symbol = 'Z';
            height = 100;
            width = 100;
            ascent = 68;
            descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine($"{symbol} (pointsize {this.pointSize})");
        }
    }
}