using System;

namespace Samples.Structural
{
    public class AdapterSample
    {
        public static void Main()
        {
            // Non-adapted chemical compound
            var unknown = new Compound("Unknown");
            unknown.Display();

            // Adapted chemical compounds
            Compound water = new RichCompound("Water");
            water.Display();

            Compound benzene = new RichCompound("Benzene");
            benzene.Display();

            Compound ethanol = new RichCompound("Ethanol");
            ethanol.Display();
        }
    }
    
    internal class Compound
    {
        protected float boilingPoint;
        protected string chemical;
        protected float meltingPoint;
        protected string molecularFormula;
        protected double molecularWeight;
        
        public Compound(string chemical)
        {
            this.chemical = chemical;
        }

        public virtual void Display()
        {
            Console.WriteLine($"\nCompound: {chemical} ------ ");
        }
    }
    
    internal class RichCompound : Compound
    {
        private ChemicalDatabank bank;

        // Constructor
        public RichCompound(string name)
            : base(name)
        {
        }

        public override void Display()
        {
            // The Adaptee
            bank = new ChemicalDatabank();

            boilingPoint = bank.GetCriticalPoint(chemical, "B");
            meltingPoint = bank.GetCriticalPoint(chemical, "M");
            molecularWeight = bank.GetMolecularWeight(chemical);
            molecularFormula = bank.GetMolecularStructure(chemical);

            base.Display();
            Console.WriteLine($" Formula: {molecularFormula}");
            Console.WriteLine($" Weight : {molecularWeight}");
            Console.WriteLine($" Melting Pt: {meltingPoint}");
            Console.WriteLine($" Boiling Pt: {boilingPoint}");
        }
    }

    internal class ChemicalDatabank
    {
        // The databank 'legacy API'
        public float GetCriticalPoint(string compound, string point)
        {
            // Melting Point
            if (point == "M")
                switch (compound.ToLower())
                {
                    case "water": return 0.0f;
                    case "benzene": return 5.5f;
                    case "ethanol": return -114.1f;
                    default: return 0f;
                }
            // Boiling Point
            switch (compound.ToLower())
            {
                case "water": return 100.0f;
                case "benzene": return 80.1f;
                case "ethanol": return 78.3f;
                default: return 0f;
            }
        }

        public string GetMolecularStructure(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return "H20";
                case "benzene": return "C6H6";
                case "ethanol": return "C2H5OH";
                default: return "";
            }
        }

        public double GetMolecularWeight(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return 18.015;
                case "benzene": return 78.1134;
                case "ethanol": return 46.0688;
                default: return 0d;
            }
        }
    }
}