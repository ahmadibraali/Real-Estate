
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Real_Estate.API.Extensions;
using Real_Estate.Application;
using Real_Estate.Context;
using Real_Estate.Identity;
using Real_Estate.Identity.Context;
using Real_Estate.Infrastructure;

namespace Real_Estate.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
            }).ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressMapClientErrors = true;
            });
            builder.Services.AddSwaggerExtension();
            builder.Services.AddcontextInfrastructure(builder.Configuration);
            builder.Services.AddIdentityInfrastructure(builder.Configuration);
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplicationLayer();
            builder.Services.AddApiVersioningExtension();
            builder.Services.AddAuthorization(opt =>
            {
                opt.AddPolicy("RequireOnlyAdminAndDeveloper", policy => policy.RequireRole("Admin", "Developer"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerExtension();


            app.MapControllers();

            app.Run();
        }
    }
}