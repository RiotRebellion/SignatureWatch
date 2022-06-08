using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace SignatureWatch.UseCases.Features
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services) => services
            .AddMediatR(typeof(DependencyInjection).Assembly);
    }
}
