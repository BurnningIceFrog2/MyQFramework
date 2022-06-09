using System;
namespace LGUVirtualOffice.Framework
{
    public interface IQueryAsync : ICanGetService, ICanGetModel, ICanGetUtility, ICanSubscribeEvent
    {
        void DoQueryAsync<R>(Action<R> onQueryComleted);
    }
}
