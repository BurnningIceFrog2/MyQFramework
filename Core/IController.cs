namespace LGUVirtualOffice.Framework
{
    public interface IController :ICanInject,ICanGetModel,ICanGetUtility,ICanSendCommand,ICanSubscribeEvent,ICanSendQuery
    {
    }
}
