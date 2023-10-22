using Real_Estate.Application.DTOs.Email;
using Real_Estate.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Interfaces.Services
{
    public interface IEmailService
    {
        public MailSettings _mailSettings { get; }
        Task SendEmailAsync(EmailRequest request);
    }
}
