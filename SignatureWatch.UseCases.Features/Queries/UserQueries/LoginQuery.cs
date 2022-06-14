using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.UserQueries
{
    public class LoginQuery : IRequest<AuthentificationResponse>
    {
        public LoginDTO LoginViewModel { get; set; }

        public class GetUserQueryHandle : IRequestHandler<LoginQuery, AuthentificationResponse>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetUserQueryHandle(IDbContext dbContext, IMapper mapper)
            {
                (_dbContext, _mapper) = (dbContext, mapper);
            }

            public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                var loginViewModel = _mapper.Map<User>(request.LoginViewModel);
                User? user = _dbContext.Set<User>().FirstOrDefault(u => u.Username == loginViewModel.Username);

                if (user == null) return string.Empty;

                else return user.Id.ToString();
            }
        }
    }
}
