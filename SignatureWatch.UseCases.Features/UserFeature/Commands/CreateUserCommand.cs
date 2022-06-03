using AutoMapper;
using MediatR;
using SignatureWatch.UseCases.Interfaces.Persistence;

namespace SignatureWatch.UseCases.Features.UserFeature.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public CreateUserCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                (_dbContext, _mapper) = (dbContext, mapper);
            }

            public async Task<string> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                
            }
        }
    }
}
