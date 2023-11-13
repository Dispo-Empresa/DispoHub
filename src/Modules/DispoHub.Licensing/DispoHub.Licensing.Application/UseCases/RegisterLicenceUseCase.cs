using DispoHub.Licensing.Domain.Repositories;
using DispoHub.Licensing.Domain.UseCases;
using DispoHub.Shared.Domain.Entities;
using DispoHub.Shared.Domain.Enums;
using System.Text;

namespace DispoHub.Licensing.Application.UseCases
{
    public class RegisterLicenceUseCase : IRegisterLicenceUseCase
    {
        private readonly ILicenceRepository _licenceRepository;

        public RegisterLicenceUseCase(ILicenceRepository licenceRepository)
        {
            _licenceRepository = licenceRepository;
        }

        public Licence Register(Licence licence)
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

            _licenceRepository.Create(licence);

            return licence;
        }

        private void Validate(Licence licence)
        {
            var licenceExistent = _licenceRepository.GetByCompanyId(licence.CompanyId);

            if (licenceExistent != null && licenceExistent.ExpirationDate >= DateTime.Now)
                throw new Exception("Já existe uma licença ativa para essa empresa!");
        }
    }
}