using System;
using System.Collections.Generic;

namespace Samples.Structural
{
    public class CompositeSample
    {
        public static void Main()
        {
            // Create a tree structure
            var root =
                new CompositeElement("Picture");
            root.Add(new PrimitiveElement("Red Line"));
            root.Add(new PrimitiveElement("Blue Circle"));
            root.Add(new PrimitiveElement("Green Box"));

            // Create a branch
            var comp =
                new CompositeElement("Two Circles");
            comp.Add(new PrimitiveElement("Black Circle"));
            comp.Add(new PrimitiveElement("White Circle"));
            root.Add(comp);

            // Add and remove a PrimitiveElement
            var pe =
                new PrimitiveElement("Yellow Line");
            root.Add(pe);
            root.Remove(pe);

            // Recursively display nodes
            root.Display(1);
        }
    }

    internal abstract class DrawingElement
    {
        protected string name;

        public DrawingElement(string name)
        {
            this.name = name;
        }

        public abstract void Add(DrawingElement d);
        public abstract void Remove(DrawingElement d);
        public abstract void Display(int indent);
    }

    internal class PrimitiveElement : DrawingElement
    {
        public PrimitiveElement(string name)
            : base(name)
        {
        }

        public override void Add(DrawingElement c)
        {
            Console.WriteLine(
                "Cannot add to a PrimitiveElement");
        }

        public override void Remove(DrawingElement c)
        {
            Console.WriteLine(
                "Cannot remove from a PrimitiveElement");
        }

        public override void Display(int indent)
        {
            Console.WriteLine(
                new string('-', indent) + " " + name);
        }
    }

    internal class CompositeElement : DrawingElement
    {
        private readonly List<DrawingElement> elements =
            new List<DrawingElement>();

        public CompositeElement(string name)
            : base(name)
        {
        }

        public override void Add(DrawingElement d)
        {
            elements.Add(d);
        }

        public override void Remove(DrawingElement d)
        {
            elements.Remove(d);
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new string('-', indent) +
                              "+ " + name);

            // Display each child element on this node
            foreach (var d in elements) d.Display(indent + 2);
        }
    }
}