using LicenceEntity = DispoHub.Core.Domain.Entities.Licence;

namespace DispoHub.Licence.Domain.UseCases
{
    public interface IRegisterLicenceUseCase
    {
        LicenceEntity Register(LicenceEntity licence);
    }
}
