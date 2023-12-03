using DispoHub.Mensager.Application.Interfaces;
using DispoHub.Mensager.Application.Services;
using DispoHub.Mensager.Infrastructure.Messaging.Queues.Subscribers;
using Microsoft.Extensions.DependencyInjection;

namespace DispoHub.Mensager.Ioc
{
    public class Injector
    {
        public static void InjectIocServices(IServiceCollection service)
        {
            service.AddTransient<IEmailMensagerService, EmailMensagerService>();
            service.AddHostedService<EmailMensagerSubscriber>();
        }
    }
}