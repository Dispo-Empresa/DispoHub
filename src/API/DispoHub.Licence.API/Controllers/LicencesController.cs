using DispoHub.Core.Domain.Enums;
using DispoHub.Licence.API.Models;
using DispoHub.Licence.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DispoHub.Licence.API.Controllers
{
    [Route("/api/v1/licences")]
    [ApiController]
    public class LicencesController : ControllerBase
    {
        private readonly ILicenceRepository _licenceRepository;

        public LicencesController(ILicenceRepository licenceRepository)
        {
            _licenceRepository = licenceRepository;
        }

        [HttpGet]
        public IActionResult Get(long companyId)
        {
            var licence = _licenceRepository.GetByCompanyId(companyId);

            if (licence.ExpirationDate >= DateTime.Now)
            {
                return Ok(new ResponseModelBuilder().WithSuccess(true)
                                                    .WithData(new GetLicenceResponse()
                                                    {
                                                        Key = licence.Key,
                                                        CreationDate = licence.CreationDate,
                                                        ExpirationDate = licence.ExpirationDate,
                                                        Type = licence.Type
                                                    })
                                                    .Build());
            }
            else
            {
                return BadRequest(new ResponseModelBuilder().WithSuccess(false)
                                                            .WithMessage("Licença expirada, por favor entre em contato com o Dispo para renovação.")
                                                            .Build());
            }

        }

        [HttpPost]
        public IActionResult Create()
        {
            Core.Domain.Entities.Licence licence = new Core.Domain.Entities.Licence();

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
            licence.CompanyId = 2;

            var createdLicence = _licenceRepository.Create(licence);

            return Created("/api/v1/licences", createdLicence);
        }
    }
}