using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Real_Estate.Application.DTOs.Email;
using Real_Estate.Application.Interfaces.Services;
using Real_Estate.Domain.Settings;

namespace Real_Estate.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public MailSettings _mailSettings { get; }


        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(EmailRequest request)
        {
            try
            {
                // Create Message
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(request.From ?? _mailSettings.EmailFrom);
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
