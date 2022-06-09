using System;
namespace LGUVirtualOffice.Framework
{
    public interface IChainEvent : IEvent
    {
        //IChainEvent NextEvent<T>(Action<T> onEvent) where T : IEvent;
    }
}
