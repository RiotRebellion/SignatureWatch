using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SignatureWatch.UseCases.Features.Services;
using SignatureWatch.UseCases.Features.Services.Interfaces;

namespace SignatureWatch.UseCases.Features
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services) => services
            .AddScoped<IAuthentification, AuthentificationService>()
            .AddMediatR(typeof(DependencyInjection).Assembly);
    }
}
