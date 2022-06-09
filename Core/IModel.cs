namespace LGUVirtualOffice.Framework
{
    public interface IModel:ICanInject,ICanGetUtility,ICanTriggerEvent
    {
        void OnInit();
    }
}
