using DispoHub.Mensager.Application.Models.Request;

namespace DispoHub.Mensager.Application.Interfaces
{
    public interface IEmailMensagerService
    {
        Task SendEmailAsync(EmailMensagerRequestModel request);
    }
}
