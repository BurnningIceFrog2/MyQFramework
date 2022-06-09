using System;
namespace LGUVirtualOffice.Framework
{

    public class DefaultChainEventUnSubcribe : IChainEventUnSubscribe
    {
        private Action mOnUnSub;
        private Type mChainEventType;
        public DefaultChainEventUnSubcribe(Type chainEventType,Action onUnSub) 
        {
            mChainEventType = chainEventType;
            mOnUnSub = onUnSub;
        }

        public Type GetChainEventType()
        {
            return mChainEventType;
        }

        public void UnSubscribe()
        {
            mOnUnSub?.Invoke();
            mOnUnSub = null;
            mChainEventType = null;
        }
    }
}
