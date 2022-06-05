using System;
namespace com.QFramework
{
    public interface ITypeEventSystem
    {
        void TriggerEvent<T>() where T : IEvent, new();
        void TriggerEvent<T>(T e) where T : IEvent;
        void TriggerChainEvent<T>(params IEvent[] events) where T : IChainEvent;
        public void TriggerChainEvent<T>() where T : IChainEvent;
        IUnSubscribe SubscribeEvent<T>(Action<T> onEvent) where T : IEvent;
        IChainEventUnSubscribe SubscribeChainEvent<T, K>(Action<K> onEvent) where T : IChainEvent where K : IEvent;
        IChainEventUnSubscribe SubscribeChainEvent<K>(Type chainEventType,Action<K> onEvent) where K : IEvent;
        void UnSubscribeEvent<T>(Action<T> onEvent) where T : IEvent;
        public void UnSubscribeChainEvent<T>() where T : IChainEvent;

        public void UnSubscribeChainEvent(Type chainEventType);
        public void UnSubscribeEventFromChainEvent<T, K>() where T : IChainEvent where K : IEvent;
    }
}
