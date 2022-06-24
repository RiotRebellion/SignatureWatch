using SignatureWatch.Infrastructure.Persistence;
using SignatureWatch.Presentation.WebApp.Installers.Interfaces;
using SignatureWatch.UseCases.Contracts;
using SignatureWatch.UseCases.Features;

namespace SignatureWatch.Presentation.WebApp.Installers.InstallServices
{
    public class DllInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddAuthentication();
            services.AddAuthorization();

            services.AddDatabase(configuration.GetSection("Database"));
            services.AddContracts();
            services.AddFeatures();
        }
    }
}
