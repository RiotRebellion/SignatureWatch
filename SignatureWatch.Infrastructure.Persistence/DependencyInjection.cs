using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignatureWatch.Infrastructure.Persistence.Contexts;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Postges")))
            .AddScoped<IDbContext>(services => services.GetRequiredService<ApplicationDbContext>());
    }
}
