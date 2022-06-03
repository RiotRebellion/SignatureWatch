using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Interfaces.Persistence;

namespace SignatureWatch.UseCases.Features.UserFeatures.Commands
{
    public class CreateUserCommand : IRequest<int> 
    {
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
        {
            private readonly IDbContext _dbContext;

            public CreateUserCommandHandler(IDbContext dbContext) =>
                _dbContext = dbContext;

            public Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                
            }
        }
    }
}
