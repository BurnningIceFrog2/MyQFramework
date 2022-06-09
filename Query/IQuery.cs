namespace LGUVirtualOffice.Framework
{
    public interface IQuery<R>:ICanGetService,ICanGetModel,ICanGetUtility,ICanSubscribeEvent,ICanSendQuery
    {
        R DoQuery();
    }
}
