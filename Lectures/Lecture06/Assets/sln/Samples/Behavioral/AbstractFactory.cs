using System;

namespace Samples.Behavioral
{
    public class MainApp
    {
        public static void Main()
        {
            // Create and run the African animal world
            ContinentFactory africa = new AfricaFactory();
            var world = new AnimalWorld(africa);
            world.RunFoodChain();

            // Create and run the American animal world
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();

            Console.ReadKey();
        }
    }

    internal abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    internal class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    internal class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    internal abstract class Herbivore
    {
    }

    internal abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    internal class Wildebeest : Herbivore
    {
    }

    internal class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(GetType().Name +
                              " eats " + h.GetType().Name);
        }
    }

    internal class Bison : Herbivore
    {
    }

    internal class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(GetType().Name +
                              " eats " + h.GetType().Name);
        }
    }

    internal class AnimalWorld
    {
        private readonly Carnivore carnivore;
        private readonly Herbivore herbivore;

        public AnimalWorld(ContinentFactory factory)
        {
            carnivore = factory.CreateCarnivore();
            herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            carnivore.Eat(herbivore);
        }
    }
}