using DispoHub.Licence.Domain.Enums;
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
        public IActionResult Get()
        {
            var licences = _licenceRepository.GetAll();

            return Ok(licences);
        }

        [HttpPost]
        public IActionResult Create()
        {
            Domain.Entities.Licence licence = new Domain.Entities.Licence();
            licence.CreationDate = DateTime.Now;
            licence.ExpirationDate = DateTime.Now.AddYears(1);
            licence.Type = eLicenceType.Default;
            licence.Key = "ABC123";

            var createdLicence  = _licenceRepository.Create(licence);

            return Created("/api/v1/licences", createdLicence);
        }
    }
}