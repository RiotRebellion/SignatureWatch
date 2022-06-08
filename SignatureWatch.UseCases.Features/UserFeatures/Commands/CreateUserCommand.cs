using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Interfaces.Persistence;

namespace SignatureWatch.UseCases.Features.UserFeatures.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public RegistrationViewModel RegistrationVM { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public CreateUserCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                (_dbContext, _mapper) = (dbContext, mapper);
            }

            //TODO: add validation
            public async Task<string> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {                
                var user = _mapper.Map<User>(command.RegistrationVM);

                if (_dbContext.Set<User>().Where(i => i.Username == user.Username).Any())
                {
                    return "Данный пользователь уже зарегистрирован в системе";
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
