using AutoMapper;
using MediatR;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.EmployeeCommands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public EmployeeDTO SignatureDTO;

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public CreateEmployeeCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
            {
                return 0;
            }
        }
    }
}
