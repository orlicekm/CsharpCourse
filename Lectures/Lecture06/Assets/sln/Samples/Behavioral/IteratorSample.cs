using System;
using System.Collections;

namespace Samples.Behavioral
{
    public class IteratorSample
    {
        public static void Main()
        {
            var aggregate = new ConcreteAggregate {[0] = "Item A", [1] = "Item B", [2] = "Item C", [3] = "Item D"};

            // Create Iterator and provide aggregate
            var iterator = aggregate.CreateIterator();

            Console.WriteLine("Iterating over collection:");
            var item = iterator.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = iterator.Next();
            }
        }
    }

    internal abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    internal class ConcreteAggregate : Aggregate
    {
        private readonly ArrayList items = new ArrayList();

        public int Count => items.Count;

        public object this[int index]
        {
            get => items[index];
            set => items.Insert(index, value);
        }

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
    }

    internal abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    internal class ConcreteIterator : Iterator
    {
        private readonly ConcreteAggregate aggregate;
        private int current;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public override object First()
        {
            return aggregate[0];
        }

        public override object Next()
        {
            object ret = null;
            if (current < aggregate.Count - 1) ret = aggregate[++current];

            return ret;
        }

        public override object CurrentItem()
        {
            return aggregate[current];
        }

        public override bool IsDone()
        {
            return current >= aggregate.Count;
        }
    }
}