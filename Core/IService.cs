namespace com.QFramework 
{
    public interface IService : ICanInject,ICanGetModel,ICanGetUtility,ICanSubscribeEvent,ICanTriggerEvent,ICanSendQuery
    {
        void OnInit();
    }
}
