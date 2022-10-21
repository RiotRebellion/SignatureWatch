using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.DistributionQueries
{
    public class GetAllDistributionsQuery : IRequest<IEnumerable<DistributionViewModel>>
    {
        public class GetAllDistributionQueryHandler : IRequestHandler<GetAllDistributionsQuery, IEnumerable<DistributionViewModel>>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public GetAllDistributionQueryHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<IEnumerable<DistributionViewModel>> Handle(GetAllDistributionsQuery request, CancellationToken cancellationToken)
            {
                var distributions = await _dbContext.Set<Distribution>().ToListAsync();
                return _mapper.Map<IEnumerable<DistributionViewModel>>(distributions);
            }
        }
    }
}
