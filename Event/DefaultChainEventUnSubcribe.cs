using System;
namespace com.QFramework
{

    public class DefaultChainEventUnSubcribe : IChainEventUnSubscribe
    {
        private ITypeEventSystem mTypeEventSystem;
        private Action mOnUnSub;
        private Type mChainEventType;
        public DefaultChainEventUnSubcribe(ITypeEventSystem typeEventSystem,Type chainEventType,Action onUnSub) 
        {
            mTypeEventSystem = typeEventSystem;
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
            mTypeEventSystem = null;
            mChainEventType = null;
        }

        public void UnSubscribeAllEventsOnChain()
        {
            if (mTypeEventSystem != null) 
            {
                mTypeEventSystem.UnSubscribeChainEvent(mChainEventType);
                mTypeEventSystem = null;
                mOnUnSub = null;
            }
        }
    }
}
