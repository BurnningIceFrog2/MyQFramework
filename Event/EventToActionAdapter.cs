using System;
namespace LGUVirtualOffice.Framework
{
    public struct EventToActionAdapter
    {
        private Action<IEvent> mAdapterAction;
        private int mHashCode;
        public EventToActionAdapter(int hashCode,Action<IEvent> adapterAction) 
        {
            mHashCode = hashCode;
            mAdapterAction = adapterAction;
        }
        public void Clear() 
        {
            mAdapterAction = null;
        }
        public Action<IEvent> GetAdapterAction() 
        {
            return mAdapterAction;
        }
        public int GetActionHashCode() 
        {
            return mHashCode;
        }
    }
}
