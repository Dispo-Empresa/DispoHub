using RabbitMQ.Client;

namespace DispoHub.Mensager.Infrastructure.Messaging.Queues.Interfaces
{
    public interface ISubscriberBase
    {
        IConnection? Connection { get; set; }
        IModel? Channel { get; set; }

        void StartConsuming();
    }
}
