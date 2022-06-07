using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Interfaces.Persistence;

namespace SignatureWatch.UseCases.Features.UserFeatures.Queries
{
    public class GetUserQuery : IRequest<string>
    {
        public AuthVM AuthVM { get; set; }

        public class GetUserQueryHandle : IRequestHandler<GetUserQuery, string>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetUserQueryHandle(IDbContext dbContext, IMapper mapper)
            {
                (_dbContext, _mapper) = (dbContext, mapper);
            }

            public async Task<string> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                var user = _mapper.Map<User>(request.AuthVM);
                bool isLoginPasswordCorrect = _dbContext.Set<User>()
                    .Where(u => u.Username == user.Username)
                    .Where(u => u.Password == user.Password)
                    .Any();

                if (isLoginPasswordCorrect)
                {
                    return _dbContext.Set<User>().Where(u => u.Username == user.Username).FirstOrDefault().Id.ToString();
                }
                else 
                {
                    return null;
                }

            }
        }
    }
}
