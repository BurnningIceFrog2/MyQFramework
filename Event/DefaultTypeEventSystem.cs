using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.QFramework
{
    public class DefaultTypeEventSystem : ITypeEventSystem
    {
        private Dictionary<Type, ISubscription> eventSubscriptionPool = new Dictionary<Type, ISubscription>(32);
        private Dictionary<Type,Dictionary<int, EventToActionAdapter>> typeAdapterPool = new Dictionary<Type, Dictionary<int, EventToActionAdapter>>(32);
        private Dictionary<Type, LinkedList<Type>> chainEventPool = new Dictionary<Type, LinkedList<Type>>(8);
        private Dictionary<Type, LinkedList<int>> chainEventAdapterPool = new Dictionary<Type, LinkedList<int>>(8);
        public IUnSubscribe SubscribeEvent<T>(Action<T> onEvent) where T : IEvent
        {
            Type t = typeof(T);
            ISubscription subscription;
            var adapter = new EventToActionAdapter((ievent) => { onEvent?.Invoke((T)ievent); });
            if (eventSubscriptionPool.TryGetValue(t, out subscription))
            {
                typeAdapterPool[t].Add(onEvent.GetHashCode(), adapter);
            }
            else 
            {
                subscription = new TypeEventSubscription();
                eventSubscriptionPool.Add(t, subscription);
                typeAdapterPool.Add(t, new Dictionary<int, EventToActionAdapter>(4) { { onEvent.GetHashCode(), adapter } });
            }
            return subscription.Subscribe(adapter);
        }

        public IChainEventUnSubscribe SubscribeChainEvent<T,K>(Action<K> onEvent) where T : IChainEvent where K:IEvent
        {
            Type chainEventType = typeof(T);
            return SubscribeChainEvent(chainEventType,onEvent);
        }
        public IChainEventUnSubscribe SubscribeChainEvent<K>(Type chainEventType, Action<K> onEvent) where K : IEvent 
        {
            Type eventType = typeof(K);
            LinkedList<Type> eventTypeList;
            LinkedList<int> chainActionList;
            if (!chainEventPool.TryGetValue(chainEventType, out eventTypeList))
            {
                eventTypeList = new LinkedList<Type>();
                chainActionList = new LinkedList<int>();
                chainEventPool.Add(chainEventType, eventTypeList);
                chainEventAdapterPool.Add(chainEventType, chainActionList);
            }
            else
            {
                if (!chainEventAdapterPool.TryGetValue(chainEventType, out chainActionList))
                {
                    chainActionList = chainEventAdapterPool[chainEventType];
                }
            }
            if (!eventTypeList.Contains(eventType))
            {
                eventTypeList.AddLast(eventType);
            }
            chainActionList.AddLast(onEvent.GetHashCode());
            IUnSubscribe eventUnSub = SubscribeEvent(onEvent);
            return new DefaultChainEventUnSubcribe(this,chainEventType, () => {
                if (chainEventAdapterPool.TryGetValue(chainEventType, out var adapterList))
                {
                    adapterList.Remove(onEvent.GetHashCode());
                    if (adapterList.Count == 0)
                    {
                        chainEventAdapterPool.Remove(chainEventType);
                    }
                }
                if (chainEventPool.TryGetValue(chainEventType, out var eventTypeList))
                {
                    eventTypeList.Remove(eventType);
                    if (eventTypeList.Count == 0)
                    {
                        chainEventPool.Remove(chainEventType);
                    }
                }
                eventUnSub.UnSubscribe();
            });
        }
        public void TriggerEvent<T>() where T : IEvent, new()
        {
            TriggerEvent(new T());
        }

        public void TriggerEvent<T>(T e) where T : IEvent
        {
            if (eventSubscriptionPool.TryGetValue(e.GetType(), out ISubscription subscription))
            {
                subscription.TriggerEvent(e);
            }
        }

        public void TriggerChainEvent<T>(params IEvent[] events) where T:IChainEvent 
        {
            LinkedList<Type> chainEventTypeList;
            Type chainEventType = typeof(T);
            if (chainEventPool.TryGetValue(chainEventType, out chainEventTypeList)) 
            {
                foreach (var mEvent in events)
                {
                    if (chainEventTypeList.Contains(mEvent.GetType())) 
                    {
                        TriggerEvent(mEvent);
                    }
                }
            }
        }
        public void TriggerChainEvent<T>() where T : IChainEvent
        {
            LinkedList<Type> chainEventTypeList;
            Type chainEventType = typeof(T);
            if (chainEventPool.TryGetValue(chainEventType, out chainEventTypeList))
            {
                foreach (var eventType in chainEventTypeList)
                {
                    TriggerEvent((IEvent)Activator.CreateInstance(eventType));
                }
            }
         }

        public void UnSubscribeEvent<T>(Action<T> onEvent) where T : IEvent
        {
            Type t = typeof(T);
            if (eventSubscriptionPool.TryGetValue(t, out ISubscription subscription))
            {
                int hash = onEvent.GetHashCode();
                Dictionary<int, EventToActionAdapter> adapterPool = typeAdapterPool[t];
                if (adapterPool.TryGetValue(hash, out var adapter)) 
                {
                    subscription.UnSubscribe(adapter);
                    adapterPool.Remove(hash);
                    if (subscription.SubscribeCount <= 0) 
                    {
                        eventSubscriptionPool.Remove(t);
                        typeAdapterPool.Remove(t);
                    }
                }
            }
        }
        public void UnSubscribeChainEvent<T>() where T:IChainEvent 
        {
            Type chainEventType = typeof(T);
            UnSubscribeChainEvent(chainEventType);
        }
        public void UnSubscribeChainEvent(Type chainEventType)
        {
            LinkedList<Type> chainEventTypeList;
            if (chainEventPool.TryGetValue(chainEventType, out chainEventTypeList))
            {
                if (chainEventAdapterPool.TryGetValue(chainEventType, out var chainEventAdapterList))
                {
                    UnSubscribeChainEvent(chainEventTypeList, chainEventAdapterList);
                    chainEventAdapterPool.Remove(chainEventType);
                }
                chainEventPool.Remove(chainEventType);
            }
        }
        public void UnSubscribeEventFromChainEvent<T, K>() where T : IChainEvent where K : IEvent 
        {
            LinkedList<Type> chainEventTypeList;
            LinkedList<int> chainEventAdapterList;
            Type chainEventType = typeof(T);
            Type eventType = typeof(K);
            if (chainEventPool.TryGetValue(chainEventType, out chainEventTypeList))
            {
                if (!chainEventTypeList.Contains(eventType)) 
                {
                    return;
                }
                if (chainEventAdapterPool.TryGetValue(chainEventType, out chainEventAdapterList))
                {
                    UnSubscribeEventFromChainEvent(eventType, chainEventAdapterList);
                    if (chainEventAdapterList.Count == 0) 
                    {
                        chainEventAdapterPool.Remove(chainEventType);
                    }
                }
                chainEventTypeList.Remove(eventType);
                if (chainEventTypeList.Count == 0) 
                {
                    chainEventPool.Remove(chainEventType);
                }
            }
        }
        private void UnSubscribeChainEvent(LinkedList<Type> chainEventTypeList,LinkedList<int> chainEventAdapterList) 
        {
            foreach (var eventType in chainEventTypeList)
            {
                UnSubscribeEventFromChainEvent(eventType, chainEventAdapterList);
            }
        }
        private void UnSubscribeEventFromChainEvent(Type eventType, LinkedList<int> chainEventAdapterList) 
        {
            if (typeAdapterPool.TryGetValue(eventType, out var eventAdapterPool))
            {
                foreach (var hash in chainEventAdapterList)
                {
                    if (eventAdapterPool.ContainsKey(hash))
                    {
                        UnSubcribeEvent(eventType, hash);
                        chainEventAdapterList.Remove(hash);
                        break;
                    }
                }
            }
        }
        private void UnSubcribeEvent(Type eventType, int hash)
        {
            if (eventSubscriptionPool.TryGetValue(eventType, out ISubscription subscription))
            {
                var adapterPool = typeAdapterPool[eventType];
                if (adapterPool.TryGetValue(hash, out var adapter))
                {
                    subscription.UnSubscribe(adapter);
                    adapterPool.Remove(hash);
                }
                if (subscription.SubscribeCount <= 0)
                {
                    eventSubscriptionPool.Remove(eventType);
                    typeAdapterPool.Remove(eventType);
                }
            }
        }
    }
}
