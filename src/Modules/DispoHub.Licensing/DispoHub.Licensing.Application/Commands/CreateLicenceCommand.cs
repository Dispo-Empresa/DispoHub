using DispoHub.Licensing.Application.Response;
using MediatR;

namespace DispoHub.Licensing.Application.Commands
{
    public class CreateLicenceCommand : IRequest<LicenceResponse>
    {
        public long CompanyId { get; set; }
    }
}