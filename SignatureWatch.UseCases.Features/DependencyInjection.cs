using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SignatureWatch.UseCases.Features.Common.Behaviours;
using SignatureWatch.UseCases.Features.Common.Utils;
using SignatureWatch.UseCases.Features.Services;
using SignatureWatch.UseCases.Features.Services.Interfaces;

namespace SignatureWatch.UseCases.Features
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services) => services
            .AddScoped(typeof(StringUtil))
            .AddScoped<IAuthentification, AuthentificationService>()           
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>))
            .AddMediatR(typeof(DependencyInjection).Assembly);
    }
}
