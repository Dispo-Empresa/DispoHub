using DispoHub.API.Models;
using DispoHub.Licensing.Application.Commands;
using DispoHub.Licensing.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DispoHub.API.Controllers
{
    [Route("/api/v1/licences")]
    [ApiController]
    public class LicencesController : ControllerBase
    {
        private readonly ILicenceRepository _licenceRepository;
        private readonly IMediator _mediator;

        public LicencesController(ILicenceRepository licenceRepository, IMediator mediator)
        {
            _licenceRepository = licenceRepository;
            _mediator = mediator;
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
        public async Task<IActionResult> Create(CreateLicenceCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(new ResponseModelBuilder().WithSuccess(true)
                                                .WithData(new GetLicenceResponse()
                                                {
                                                    Key = result.Key,
                                                    CreationDate = result.CreationDate,
                                                    ExpirationDate = result.ExpirationDate,
                                                    Type = result.Type
                                                })
                                                .Build());
        }
    }
}