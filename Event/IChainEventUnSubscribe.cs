using System;
namespace LGUVirtualOffice.Framework
{
    public interface IChainEventUnSubscribe:IUnSubscribe
    {
        Type GetChainEventType();
    }
}
