using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.SoftwareQueries
{
    public class GetAllSoftwaresQuery : IRequest<IEnumerable<SoftwareViewModel>>
    {
        public class GetAllSoftwaresQueryHandler : IRequestHandler<GetAllSoftwaresQuery, IEnumerable<SoftwareViewModel>>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public GetAllSoftwaresQueryHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<SoftwareViewModel>> Handle(GetAllSoftwaresQuery request, CancellationToken cancellationToken)
            {
                var softwares = await _dbContext.Set<Software>()
                    .Include(x => x.SoftwareType)
                    .Include(x => x.Distribution)
                    .ToListAsync();

                return _mapper.Map<IEnumerable<SoftwareViewModel>>(softwares);
            }
        }
    }
}
