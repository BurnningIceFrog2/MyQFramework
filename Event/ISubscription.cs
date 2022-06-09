namespace LGUVirtualOffice.Framework
{
    public interface ISubscription
    {
        int SubscribeCount { get; }
        IUnSubscribe Subscribe(EventToActionAdapter adapter);
        bool UnSubscribe(int hashCode);
        void TriggerEvent(IEvent e);
    }
}
