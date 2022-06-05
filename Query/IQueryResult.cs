using System;
namespace com.QFramework
{

    public interface IQueryResult<R>
    {
        void OnQuerySucceed(Action<R> onQuerySucceed);
        void OnQueryFailed(Action onQueryFailed);
    }
}
