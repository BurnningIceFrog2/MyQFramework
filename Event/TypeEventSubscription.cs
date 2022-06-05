using System;
using System.Collections.Generic;
namespace com.QFramework
{
    public class TypeEventSubscription : ISubscription
    {
        private Action<IEvent> mOnEvent;
        private int subscribeCount;
        public TypeEventSubscription() 
        {
        }
        public int SubscribeCount { get => subscribeCount;}
        public IUnSubscribe Subscribe(Action<IEvent> onEvent)
        {
            mOnEvent += onEvent;
            subscribeCount++;
            return new TypeEventSystemUnSubscribe(()=> { UnSubscribe(onEvent); });
        }

        public IUnSubscribe Subscribe(EventToActionAdapter adapter)
        {
            return Subscribe(adapter.GetAdapterAction());
        }

        public void TriggerEvent(IEvent e)
        {
            mOnEvent?.Invoke(e);
        }

        public void UnSubscribe(Action<IEvent> onEvent) 
        {
            mOnEvent -= onEvent;
        }

        public void UnSubscribe(EventToActionAdapter adapter)
        {
            UnSubscribe(adapter.GetAdapterAction());
            adapter.Clear();
            subscribeCount--;
        }
    }
}
