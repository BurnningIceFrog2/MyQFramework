namespace LGUVirtualOffice.Framework
{
    public interface IService : ICanInject,ICanGetService,ICanGetModel,ICanGetUtility,ICanSubscribeEvent,ICanTriggerEvent,ICanSendQuery
    {
        void OnInit();
    }
}
