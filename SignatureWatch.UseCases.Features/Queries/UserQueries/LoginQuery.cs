using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses;
using SignatureWatch.UseCases.Features.Services.Interfaces;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.UserQueries
{
    public class LoginQuery : IRequest<AuthentificationResponse>
    {
        public LoginDTO LoginDTO { get; set; }

        public class LoginQueryHandle : IRequestHandler<LoginQuery, AuthentificationResponse>
        {
            private readonly IAuthentification _authentification;
            private readonly IMapper _mapper;

            public LoginQueryHandle(IAuthentification authentification, IMapper mapper)
            {
                (_authentification, _mapper) = (authentification, mapper);
            }

            public async Task<AuthentificationResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                var user = _mapper.Map<User>(request.LoginDTO);

                return await _authentification.LoginAsync(user);
            }
        }
    }
}
