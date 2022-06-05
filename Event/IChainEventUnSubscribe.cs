using System;
namespace com.QFramework
{
    public interface IChainEventUnSubscribe:IUnSubscribe
    {
        void UnSubscribeAllEventsOnChain();
        Type GetChainEventType();
    }
}
