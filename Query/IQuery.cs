namespace com.QFramework
{
    public interface IQuery<R>:ICanGetService,ICanGetModel,ICanGetUtility,ICanSubscribeEvent,ICanSendQuery
    {
        R DoQuery();
    }
}
