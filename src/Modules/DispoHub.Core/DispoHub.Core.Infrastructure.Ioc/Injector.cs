using DispoHub.Core.Domain.Repositories;
using DispoHub.Core.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DispoHub.Core.Infrastructure.Ioc
{
    public class Injector
    {
        public static void InjectIoCServices(IServiceCollection serviceColletion)
        {
            InjectRepositories(serviceColletion);
            InjectServices(serviceColletion);
            InjectGenerics(serviceColletion);
        }

        private static void InjectRepositories(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped<ICompanyRepository, CompanyRepository>();
        }

        private static void InjectServices(IServiceCollection serviceColletion)
        {
        }

        private static void InjectGenerics(IServiceCollection serviceColletion)
        {
        }
    }
}