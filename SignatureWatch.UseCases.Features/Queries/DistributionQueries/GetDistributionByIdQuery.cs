using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.DistributionQueries
{
    public class GetDistributionByIdQuery : IRequest<DistributionViewModel>
    {
        public Guid Guid { get; set; }

        public class GetDistributionByIdQueryHandler : IRequestHandler<GetDistributionByIdQuery, DistributionViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public GetDistributionByIdQueryHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<DistributionViewModel> Handle(GetDistributionByIdQuery request, CancellationToken cancellationToken)
            {
                var distribution = await _dbContext.Set<Distribution>()
                    .Include(x => x.Formular)
                    .Include(x => x.Software)
                    .FirstOrDefaultAsync(x => x.Guid == request.Guid);
                return _mapper.Map<DistributionViewModel>(distribution);
            }
        }
    }
}
