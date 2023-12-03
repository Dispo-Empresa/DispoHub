using Microsoft.Extensions.DependencyInjection;

namespace DispoHub.Mensager.Ioc
{
    public class Injector
    {
        public static void InjectIocServices(IServiceCollection service)
        {
            service.AddTransient<IEmailSenderService, EmailSenderService>();
            service.AddHostedService<EmailSenderSubscriber>();
        }
    }
}
