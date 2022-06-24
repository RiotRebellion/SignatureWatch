using SignatureWatch.Presentation.WebApp.Installers.Interfaces;

namespace SignatureWatch.Presentation.WebApp.Installers.Extentions
{
    internal static class InstallerExtentions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            typeof(Program).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>()
                .ToList()
                .ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
