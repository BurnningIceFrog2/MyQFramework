using System;
namespace com.QFramework
{
    public interface IChainEvent : IEvent
    {
        //IChainEvent NextEvent<T>(Action<T> onEvent) where T : IEvent;
    }
}
