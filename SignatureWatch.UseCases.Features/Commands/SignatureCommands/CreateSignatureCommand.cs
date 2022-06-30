using AutoMapper;
using MediatR;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SignatureCommands
{
    public class CreateSignatureCommand : IRequest<int>
    {
        public SignatureDTO SignatureDTO;

        public class CreateSignatureCommandHandler : IRequestHandler<CreateSignatureCommand, int>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public CreateSignatureCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateSignatureCommand command, CancellationToken cancellationToken)
            {
                return 0;
            }
        }
    }
}
