using DispoHub.Core.Domain.Enums;
using DispoHub.Licence.API.Models;
using DispoHub.Licence.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

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
            licence.CreationDate = DateTime.Now;
            licence.ExpirationDate = DateTime.Now.AddYears(1);
            licence.Type = eLicenceType.Default;
            licence.Key = "ABC123";
            licence.CompanyId = 1;

            var createdLicence = _licenceRepository.Create(licence);

            return Created("/api/v1/licences", createdLicence);
        }
    }
}