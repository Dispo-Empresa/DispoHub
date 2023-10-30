using DispoHub.Licence.Application.UseCases;
using DispoHub.Licence.Domain.Repositories;
using DispoHub.Licence.Domain.UseCases;
using DispoHub.Licence.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DispoHub.Licence.Infrastructure.Ioc
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
            serviceColletion.AddScoped<ILicenceRepository, LicenceRepository>();
        }

        private static void InjectServices(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped<IRegisterLicenceUseCase, RegisterLicenceUseCase>();
        }

        private static void InjectGenerics(IServiceCollection serviceColletion)
        {
        }
    }
}