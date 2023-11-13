using DispoHub.Shared.Domain.Entities;

namespace DispoHub.Licensing.Domain.UseCases
{
    public interface IRegisterLicenceUseCase
    {
        Licence Register(Licence licence);
    }
}