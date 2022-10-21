using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.ContractQueries
{
    public class GetAllContractsQuery : IRequest<IEnumerable<ContractViewModel>>
    {
        public class GetAllContractsHandler : IRequestHandler<GetAllContractsQuery, IEnumerable<ContractViewModel>>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public GetAllContractsHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<IEnumerable<ContractViewModel>> Handle(GetAllContractsQuery request, CancellationToken cancellationToken)
            {
                var contracts = await _dbContext.Set<Contract>().ToListAsync();
                return _mapper.Map<IEnumerable<ContractViewModel>>(contracts);              
            }
        }
    }
}
