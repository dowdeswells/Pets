namespace Pets.Infrastructure.Interfaces.Messaging
{
    public interface IMessaging
    {
        void Send<TCommand>(TCommand command);
    }
}