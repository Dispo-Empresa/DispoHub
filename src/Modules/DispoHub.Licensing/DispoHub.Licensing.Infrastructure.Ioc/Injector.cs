using DispoHub.Licensing.Application.Handlers;
using DispoHub.Licensing.Application.UseCases;
using DispoHub.Licensing.Domain.Repositories;
using DispoHub.Licensing.Domain.UseCases;
using DispoHub.Licensing.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DispoHub.Licensing.Infrastructure.Ioc
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