using DispoHub.Licence.API.Models;
using DispoHub.Licence.Domain.Repositories;
using DispoHub.Licence.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DispoHub.Licence.API.Controllers
{
    [Route("/api/v1/licences")]
    [ApiController]
    public class LicencesController : ControllerBase
    {
        private readonly ILicenceRepository _licenceRepository;
        private readonly IRegisterLicenceUseCase _registerLicenceUseCase;

        public LicencesController(ILicenceRepository licenceRepository, IRegisterLicenceUseCase registerLicenceUseCase)
        {
            _licenceRepository = licenceRepository;
            _registerLicenceUseCase = registerLicenceUseCase;
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

        [HttpDelete]
        public IActionResult Remove([FromRoute] long id)
        {
            _licenceRepository.Delete(id);

            var companies = _licenceRepository.GetAll();

            return Ok(companies);
        }

        [HttpPost]
        public IActionResult Create(CreateLicenceRequest request)
        {
            Core.Domain.Entities.Licence licence = new Core.Domain.Entities.Licence();

            licence.CompanyId = request.CompanyId;

            var createdLicence = _registerLicenceUseCase.Register(licence);

            return Ok(new ResponseModelBuilder().WithSuccess(true)
                                                .WithData(new GetLicenceResponse()
                                                {
                                                    Key = createdLicence.Key,
                                                    CreationDate = createdLicence.CreationDate,
                                                    ExpirationDate = createdLicence.ExpirationDate,
                                                    Type = createdLicence.Type
                                                })
                                                .Build());
        }
    }
}