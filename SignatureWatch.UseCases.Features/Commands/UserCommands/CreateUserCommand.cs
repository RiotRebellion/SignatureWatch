using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses;
using SignatureWatch.UseCases.Features.Services.Interfaces;

namespace SignatureWatch.UseCases.Features.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<AuthentificationResponse>
    {
        public RegistrationDTO RegistrationDTO { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, AuthentificationResponse>
        {
            private readonly IAuthentification _authentification;
            private readonly IMapper _mapper;

            public CreateUserCommandHandler(IAuthentification authentification, IMapper mapper)
            {
                (_authentification, _mapper) = (authentification, mapper);
            }

            public async Task<AuthentificationResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var user = _mapper.Map<User>(command.RegistrationDTO);

                return await _authentification.RegisterAsync(user);
            }
        }
    }
}
