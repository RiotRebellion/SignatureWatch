using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses;
using SignatureWatch.UseCases.Contracts.Responses.Base;

namespace SignatureWatch.UseCases.Features.Services.Interfaces
{
    public interface IAuthentification
    {
        Task<AuthentificationResponse> LoginAsync(User user);

        Task<BaseResponse> RegisterAsync(User user); 
    }
}
