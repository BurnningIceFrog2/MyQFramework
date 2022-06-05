using System;
namespace com.QFramework
{
    public struct EventToActionAdapter
    {
        private Action<IEvent> mAdapterAction;
        public EventToActionAdapter(Action<IEvent> adapterAction) 
        {
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
    }
}
