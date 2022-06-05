namespace com.QFramework 
{
    public interface IModel:ICanInject,ICanGetUtility,ICanTriggerEvent
    {
        void OnInit();
    }
}
