using DispoHub.Mensager.Application.Interfaces;
using DispoHub.Mensager.Application.Models.Request;
using DispoHub.Mensager.Infrastructure.Messaging.Queues.Interfaces;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System.Text;

namespace DispoHub.Mensager.Infrastructure.Messaging.Queues.Subscribers
{
    public class EmailMensagerSubscriber : BackgroundService, IEmailMensagerSubscriber
    {
        public IConnection? Connection { get; set; }
        public IModel? Channel { get; set; }
        private const string QUEUE_NAME = "email_sender";
        private readonly IEmailMensagerService _emailMensagerService;
        private readonly ILogger _logger;

        public EmailMensagerSubscriber(IEmailMensagerService emailMensagerService)
        {
            _emailMensagerService = emailMensagerService;
            _logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        public void StartConsuming()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            Connection = factory.CreateConnection();
            Channel = Connection.CreateModel();

            Channel.QueueDeclare(queue: QUEUE_NAME,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += Consumer_Received;

            Channel.BasicConsume(queue: QUEUE_NAME,
                                 autoAck: true,
                                 consumer: consumer);
        }

        private void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            ProcessEvent(message);
        }

        private void ProcessEvent(string message)
        {
            var request = JsonConvert.DeserializeObject<EmailMensagerRequestModel>(message);

            if (request != null)
            {
                _emailMensagerService.SendEmailAsync(request);

                _logger.Information($"Processando mensagem: {message}");
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                StartConsuming();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}
