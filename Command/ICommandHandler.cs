namespace LGUVirtualOffice.Framework
{

    public interface ICommandHandler
    {
        void ExcuteCommand(ICommand command);
        void ExcuteCommand<T>() where T:ICommand,new();
    }
}
