using DispoHub.Core.Domain.Entities;
using DispoHub.Core.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DispoHub.Licence.API.Controllers
{
    [Route("/api/v1/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var companies = _companyRepository.GetAll();

            return Ok(companies);
        }

        [HttpPost]
        public IActionResult Create()
        {
            Company company = new Company();
            company.CorporateName = "Suplementos Rodrigo";
            company.ResponsibleName = "Rodrigo";
            company.ResponsiblePhone = "(47) 9 9999-9999";
            company.CNPJ = "73.628.885/0001-41";
            company.Email = "suplementosRodrigo@gmail.com";

            var createdCompany = _companyRepository.Create(company);

            return Created("/api/v1/companies", createdCompany);
        }
    }
}
