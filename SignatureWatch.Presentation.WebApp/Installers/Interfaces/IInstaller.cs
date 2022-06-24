namespace SignatureWatch.Presentation.WebApp.Installers.Interfaces
{
    internal interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
