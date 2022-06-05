using System;
namespace com.QFramework
{
    public interface ISubscription
    {
        int SubscribeCount { get; }
        IUnSubscribe Subscribe(Action<IEvent> onEvent);
        void UnSubscribe(Action<IEvent> onEvent);
        IUnSubscribe Subscribe(EventToActionAdapter adapter);
        void UnSubscribe(EventToActionAdapter adapter);
        void TriggerEvent(IEvent e);
    }
}
