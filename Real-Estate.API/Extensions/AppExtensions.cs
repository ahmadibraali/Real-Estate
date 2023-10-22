using Swashbuckle.AspNetCore.SwaggerUI;

namespace Real_Estate.API.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "RealState API");
                options.DefaultModelRendering(ModelRendering.Model);
            });
        }
    }
}
