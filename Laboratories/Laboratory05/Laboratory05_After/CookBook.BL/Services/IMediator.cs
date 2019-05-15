using System;
using CookBook.BL.Messages;

namespace CookBook.BL.Services
{
    public interface IMediator
    {
        void Register<TMessage>(Action<TMessage> action)
            where TMessage : IMessage;

        void Send<TMessage>(TMessage message)
            where TMessage : IMessage;

        void UnRegister<TMessage>(Action<TMessage> action)
            where TMessage : IMessage;
    }
}