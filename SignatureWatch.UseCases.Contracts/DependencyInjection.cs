using Microsoft.Extensions.DependencyInjection;

namespace SignatureWatch.UseCases.Contracts
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContracts(this IServiceCollection services) => services
            .AddAutoMapper(typeof(DependencyInjection).Assembly);
    }
}
