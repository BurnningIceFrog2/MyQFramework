namespace com.QFramework
{

    public class DefaultCommandHandler : ICommandHandler
    {
        public void ExcuteCommand(ICommand command)
        {
            command.Excute();
        }

        public void ExcuteCommand<T>() where T : ICommand, new()
        {
            ExcuteCommand(new T());
        }
    }
}
