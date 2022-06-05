using System;

namespace com.QFramework
{

    public class DefaultQueryResult<R> : IQueryResult<R>
    {
        private Action<R> mOnQuerySucceed;
        private Action mOnQueryFailed;
        public void OnQuerySucceed(Action<R> onQuerySucceed) 
        {
            mOnQuerySucceed += onQuerySucceed;
        }
        public void OnQueryFailed(Action onQueryFailed) 
        {
            mOnQueryFailed += onQueryFailed;
        }
        public void TriggerSuccess(R result)
        {
            mOnQuerySucceed?.Invoke(result);
        }
        public void TriggerFailed() 
        {
            mOnQueryFailed?.Invoke();
        }
    }
}
