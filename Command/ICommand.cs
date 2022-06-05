namespace com.QFramework 
{
    public interface ICommand:ICanGetService,ICanGetModel,ICanGetUtility,ICanTriggerEvent 
    {
        public void Excute();
    }
}
