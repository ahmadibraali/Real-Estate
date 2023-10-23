using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Real_Estate.Application.Interfaces.Repositories;
using Real_Estate.Context.Repositories;


namespace Real_Estate.Context
{
    public static class ServiceRegistration
    {
        public static void AddcontextInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.EnableSensitiveDataLogging();
                    options.UseSqlServer(configuration.GetConnectionString("Cs"),
                    m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
                });
            }
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IImprovementsRepository, ImprovementsRepository>();
            services.AddTransient<ITypeOfPropertiesRepository, TypeOfPropertiesRepository>();
            services.AddTransient<ITypeOfSalesRepository, TypeOfSalesRepository>();
            services.AddTransient<IPropertiesRepository, PropertiesRepository>();
            services.AddTransient<IPropertiesImprovementsRepository, PropertiesImprovementsRepository>();
            #endregion
        }
    }
}
