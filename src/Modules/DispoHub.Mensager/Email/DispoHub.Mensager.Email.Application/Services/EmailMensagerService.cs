using DispoHub.Mensager.Application.Interfaces;
using DispoHub.Mensager.Application.Models.Request;
using DispoHub.Mensager.Domain.Enums;
using DispoHub.Mensager.Domain.Exception;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace DispoHub.Mensager.Application.Services
{
    public class EmailMensagerService : IEmailMensagerService
    {
        private readonly IConfiguration _config;

        public EmailMensagerService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(EmailMensagerRequestModel request)
        {
            try
            {
                var emailMessage = BuildEmailMessageWithCode(request);
                await SendEmailAsyncBySmtpClient(emailMessage);
            }
            catch (MensagerException emailSenderEx)
            {
                throw new MensagerException(emailSenderEx.Message);
            }
            catch (Exception ex)
            {
                throw new MensagerException(ex.Message);
            }
        }

        private MimeMessage BuildEmailMessageWithCode(EmailMensagerRequestModel request)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_config["EmailMensagerConfig:EmailFrom"]));
                email.To.Add(MailboxAddress.Parse(request.EmailTo));
                email.Subject = request.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = BuildEmailBody(request.EmailTo, request.Body, true) };

                return email;
            }
            catch (MensagerException ex)
            {
                throw new MensagerException(eEventType.Building, ex.Message);
            }
        }

        private async Task SendEmailAsyncBySmtpClient(MimeMessage emailMessage)
        {
            try
            {
                using (var smtp = new SmtpClient())
                {
                    await smtp.ConnectAsync(_config["SmtpConfig:Host"], int.Parse(_config["SmtpConfig:Port"]), bool.Parse(_config["SmtpConfig:UseSsl"]));
                    await smtp.AuthenticateAsync(_config["EmailMensagerConfig:EmailFrom"], _config["EmailMensagerConfig:AuthenticateInfo:PasswordAuth"]);
                    await smtp.SendAsync(emailMessage);
                    await smtp.DisconnectAsync(true);
                }
            }
            catch (MensagerException ex)
            {
                throw new MensagerException(eEventType.Sending, ex.Message);
            }
        }

        private string BuildEmailBody(string email, string body, bool isPasswordRecovery)
        {
            string filePath = "../../Modules/DispoHub.Shared/DispoHub.Shared.Utils/EmailLayout/layout.html";
            string passwordRecoveryObservation = isPasswordRecovery ? "Caso a redefinição de senha não tenha sido solicitada, desconsidere este email!" : string.Empty;

            string htmlContent = File.ReadAllText(filePath);

            htmlContent = htmlContent.Replace("[@CustomerEmail]", email);
            htmlContent = htmlContent.Replace("[@EmailBody]", body);
            htmlContent = htmlContent.Replace("[@PasswordRecoveryObservation]", passwordRecoveryObservation);

            return htmlContent;
        }
    }
}
