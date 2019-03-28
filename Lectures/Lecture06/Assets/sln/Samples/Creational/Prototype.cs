using System;
using System.Collections.Generic;

namespace Samples.Behavioral
{
    public class Prototype
    {
        private static void Main()
        {
            var colormanager = new ColorManager
            {
                // Initialize with standard colors
                ["red"] = new Color(255, 0, 0),
                ["green"] = new Color(0, 255, 0),
                ["blue"] = new Color(0, 0, 255),
                // User adds personalized colors
                ["angry"] = new Color(255, 54, 0),
                ["peace"] = new Color(128, 211, 128),
                ["flame"] = new Color(211, 34, 20)
            };

            // User clones selected colors
            var color1 = colormanager["red"].Clone() as Color;
            var color2 = colormanager["peace"].Clone() as Color;
            var color3 = colormanager["flame"].Clone() as Color;
        }
    }

    internal abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    internal class Color : ColorPrototype
    {
        private readonly int blue;
        private readonly int green;
        private readonly int red;

        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        // Create a shallow copy
        public override ColorPrototype Clone()
        {
            Console.WriteLine(
                $"Cloning color RGB: {red,3},{green,3},{blue,3}");
            return MemberwiseClone() as ColorPrototype;
        }
    }

    internal class ColorManager
    {
        private readonly Dictionary<string, ColorPrototype> colors =
            new Dictionary<string, ColorPrototype>();

        public ColorPrototype this[string key]
        {
            get => colors[key];
            set => colors.Add(key, value);
        }
    }
}