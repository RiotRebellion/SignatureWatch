using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.SupportQueries
{
    public class GetAllSupportsQuery : IRequest<IEnumerable<SupportViewModel>>
    {
        public class GetAllSupportQueryHandler : IRequestHandler<GetAllSupportsQuery, IEnumerable<SupportViewModel>>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetAllSupportQueryHandler(IMapper mapper, IDbContext dbContext)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<SupportViewModel>> Handle(GetAllSupportsQuery query, CancellationToken cancellationToken)
            {
                var supportList = await _dbContext.Set<Support>().ToListAsync();
                return _mapper.Map<IEnumerable<SupportViewModel>>(supportList);
            }
        }
    }
}
