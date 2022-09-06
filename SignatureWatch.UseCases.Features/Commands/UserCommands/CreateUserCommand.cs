using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Features.Services.Interfaces;

namespace SignatureWatch.UseCases.Features.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<BaseResponse>
    {
        public RegistrationDTO RegistrationDTO { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResponse>
        {
            private readonly IAuthentification _authentification;
            private readonly IMapper _mapper;

            public CreateUserCommandHandler(IAuthentification authentification, IMapper mapper)
            {
                (_authentification, _mapper) = (authentification, mapper);
            }

            public async Task<BaseResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = _mapper.Map<User>(request.RegistrationDTO);

                return await _authentification.RegisterAsync(user);
            }
        }
    }
}
