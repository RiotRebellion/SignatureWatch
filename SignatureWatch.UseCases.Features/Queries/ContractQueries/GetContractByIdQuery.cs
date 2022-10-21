using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.ContractQueries
{
    public class GetContractByIdQuery : IRequest<ContractViewModel> 
    {
        public Guid Guid { get; set; }

        public class GetContractByIdQueryHandler : IRequestHandler<GetContractByIdQuery, ContractViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public GetContractByIdQueryHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<ContractViewModel> Handle(GetContractByIdQuery request, CancellationToken cancellationToken)
            {
                var contract = await _dbContext.Set<Contract>()
                    .FirstOrDefaultAsync(x => x.Guid == request.Guid);
                return _mapper.Map<ContractViewModel>(contract);
            }
        }
    }
}
