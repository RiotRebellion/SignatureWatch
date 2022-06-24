using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses;

namespace SignatureWatch.UseCases.Features.Services.Interfaces
{
    public interface IAuthentification
    {
        Task<AuthentificationResponse> LoginAsync(User user);

        Task<AuthentificationResponse> RegisterAsync(User user); 
    }
}
