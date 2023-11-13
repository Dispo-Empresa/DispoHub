using DispoHub.Licensing.Application.Commands;
using DispoHub.Licensing.Application.Response;
using DispoHub.Licensing.Domain.Repositories;
using DispoHub.Shared.Domain.Entities;
using DispoHub.Shared.Domain.Enums;
using MediatR;
using System.Text;

namespace DispoHub.Licensing.Application.Handlers
{
    public class RegisterLicenceHandler : IRequestHandler<CreateLicenceCommand, LicenceResponse>
    {
        private readonly ILicenceRepository _licenceRepository;

        public RegisterLicenceHandler(ILicenceRepository licenceRepository)
        {
            _licenceRepository = licenceRepository;
        }

        public Task<LicenceResponse> Handle(CreateLicenceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var licence = new Licence();
                licence.CompanyId = request.CompanyId;

                Validate(licence);

                licence.CreationDate = DateTime.Now;
                licence.ExpirationDate = DateTime.Now.AddYears(1);
                licence.Type = eLicenceType.Default;
                licence.Key = GenerateLicenceKey();
                licence.CompanyId = licence.CompanyId;

                var createdLicence = _licenceRepository.Create(licence);

                return Task.FromResult(new LicenceResponse()
                {
                    Key = createdLicence.Key,
                    CreationDate = createdLicence.CreationDate,
                    ExpirationDate = createdLicence.ExpirationDate,
                    Type = createdLicence.Type
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Validate(Licence licence)
        {
            var licenceExistent = _licenceRepository.GetByCompanyId(licence.CompanyId);

            if (licenceExistent != null && licenceExistent.ExpirationDate >= DateTime.Now)
                throw new Exception("Já existe uma licença ativa para essa empresa!");
        }

        private string GenerateLicenceKey()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder license = new StringBuilder();

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int index = random.Next(characters.Length);
                license.Append(characters[index]);
            }

            return license.ToString();
        }
    }
}