namespace LGUVirtualOffice.Framework
{

    public class DefaultCommandHandler : ICommandHandler
    {
        public void ExcuteCommand(ICommand command)
        {
            command.OnExcute();
        }

        public void ExcuteCommand<T>() where T : ICommand, new()
        {
            ExcuteCommand(new T());
        }
    }
}
