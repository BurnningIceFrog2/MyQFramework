namespace LGUVirtualOffice.Framework
{
    public interface ICommand:ICanGetService,ICanGetModel,ICanGetUtility,ICanTriggerEvent 
    {
        public void OnExcute();
    }
}
