using System;

namespace LGUVirtualOffice.Framework
{

    public struct TypeEventSystemUnSubscribe : IUnSubscribe
    {
        private Action mOnUnSubscribe;
        public TypeEventSystemUnSubscribe(Action onUnSubscribe) 
        {
            mOnUnSubscribe = onUnSubscribe;
        }
        public void UnSubscribe() 
        {
            mOnUnSubscribe?.Invoke();
            mOnUnSubscribe = null;
        }
    }
}
