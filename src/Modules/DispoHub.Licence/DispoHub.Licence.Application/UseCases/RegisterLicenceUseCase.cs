using DispoHub.Core.Domain.Enums;
using DispoHub.Licence.Domain.Repositories;
using DispoHub.Licence.Domain.UseCases;
using System.Text;
using LicenceEntity = DispoHub.Core.Domain.Entities.Licence;

namespace DispoHub.Licence.Application.UseCases
{
    public class RegisterLicenceUseCase : IRegisterLicenceUseCase
    {
        private readonly ILicenceRepository _licenceRepository;

        public RegisterLicenceUseCase(ILicenceRepository licenceRepository)
        {
            _licenceRepository = licenceRepository;
        }

        public LicenceEntity Register(LicenceEntity licence)
        {
            Validate(licence);

            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder license = new StringBuilder();

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int index = random.Next(characters.Length);
                license.Append(characters[index]);
            }

            licence.CreationDate = DateTime.Now;
            licence.ExpirationDate = DateTime.Now.AddYears(1);
            licence.Type = eLicenceType.Default;
            licence.Key = license.ToString();
            licence.CompanyId = licence.CompanyId;

            return _licenceRepository.Create(licence);
        }

        private void Validate(LicenceEntity licence)
        {
            var licenceExistent = _licenceRepository.GetByCompanyId(licence.CompanyId);

            if (licenceExistent != null && licenceExistent.ExpirationDate >= DateTime.Now)
                throw new Exception("Já existe uma licença ativa para essa empresa!");
        }
    }
}
