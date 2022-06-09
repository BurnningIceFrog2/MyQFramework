using System;
namespace LGUVirtualOffice.Framework
{

    public interface IQueryResult<R>
    {
        void OnQuerySucceed(Action<R> onQuerySucceed);
        void OnQueryFailed(Action onQueryFailed);
    }
}
