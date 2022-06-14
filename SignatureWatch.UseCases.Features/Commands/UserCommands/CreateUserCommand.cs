using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<AuthentificationResponse>
    {
        public RegistrationDTO RegistrationDTO { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, AuthentificationResponse>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public CreateUserCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                (_dbContext, _mapper) = (dbContext, mapper);
            }

            public async Task<string> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var user = _mapper.Map<User>(command.RegistrationDTO);

                if (_dbContext.Set<User>().Where(i => i.Username == user.Username).Any())
                {
                    return new AuthentificationResponse
                    {
                        
                    }
                }
                {
                    _dbContext.Set<User>().Add(user);
                    await _dbContext.SaveChangesAsync();
                    return "Пользователь создан";
                }
            }
        }
    }
}
