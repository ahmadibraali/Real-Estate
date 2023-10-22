using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Real_Estate.Application.Interfaces.Services;
using Real_Estate.Domain.Settings;
using Real_Estate.Infrastructure.Services;

namespace Real_Estate.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MailSettings>(config.GetSection("MailSettings"));
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
