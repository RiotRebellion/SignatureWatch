using FluentValidation.AspNetCore;
using SignatureWatch.Infrastructure.Persistence;
using SignatureWatch.Presentation.WebApp.Installers.Interfaces;
using SignatureWatch.UseCases.Contracts;
using SignatureWatch.UseCases.Features;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SignatureWatch.Presentation.WebApp.Installers.InstallServices
{
    public class DllInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddControllers();

            services.AddDatabase(configuration.GetSection("Database"));
            services.AddContracts();
            services.AddFeatures();
            services.AddFluentValidation(fv =>
            { 
                fv.RegisterValidatorsFromAssembly(typeof(UseCases.Features.DependencyInjection).Assembly); 
            });
            services.AddFluentValidationRulesToSwagger();
        }
    }
}
