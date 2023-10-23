using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Real_Estate.Application.Interfaces.Services;
using Real_Estate.Application.Services;
using System.Reflection;

namespace Real_Estate.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IImprovementsService, ImprovementsService>();
            services.AddTransient<ITypeOfPropertiesService, TypeOfPropertiesService>();
            services.AddTransient<ITypeOfSalesService, TypeOfSalesService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPropertiesService, PropertiesService>();
            services.AddTransient<IPropertiesImprovementsService, PropertiesImprovementsService>();
            #endregion
        }
    }
}
