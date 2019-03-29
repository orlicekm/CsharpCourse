using System;
using System.Collections.Generic;

namespace Samples.Behavioral
{
    internal class MediatorSample
    {
        private static void Main()
        {
            var chatroom = new Chatroom();

            // Create participants and register them
            Participant George = new Beatle("George");
            Participant Paul = new Beatle("Paul");
            Participant Ringo = new Beatle("Ringo");
            Participant John = new Beatle("John");
            Participant Yoko = new NonBeatle("Yoko");

            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);

            // Chatting participants
            Yoko.Send("John", "Hi John!");
            Paul.Send("Ringo", "All you need is love");
            Ringo.Send("George", "My sweet Lord");
            Paul.Send("John", "Can't buy me love");
            John.Send("Yoko", "My sweet love");
        }
    }

    internal abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);

        public abstract void Send(string from, string to, string message);
    }

    internal class Chatroom : AbstractChatroom
    {
        private readonly Dictionary<string, Participant> participants = new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!participants.ContainsValue(participant)) participants[participant.Name] = participant;
            participant.Chatroom = this;
        }

        public override void Send(string from, string to, string message)
        {
            var participant = participants[to];
            participant?.Receive(from, message);
        }
    }

    internal class Participant
    {
        public Participant(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public Chatroom Chatroom { set; get; }

        public void Send(string to, string message)
        {
            Chatroom.Send(Name, to, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"{from} to {Name}: '{message}'");
        }
    }

    internal class Beatle : Participant
    {
        public Beatle(string name)
            : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.Receive(from, message);
        }
    }

    internal class NonBeatle : Participant
    {
        public NonBeatle(string name)
            : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }
}