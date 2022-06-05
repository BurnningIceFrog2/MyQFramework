using System;
namespace com.QFramework
{
    public interface IQueryAsync : ICanGetService, ICanGetModel, ICanGetUtility, ICanSubscribeEvent
    {
        void DoQueryAsync<R>(Action<R> onQueryComleted);
    }
}
