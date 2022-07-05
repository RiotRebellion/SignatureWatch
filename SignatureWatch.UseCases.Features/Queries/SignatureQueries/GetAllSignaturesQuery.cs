using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.SignatureQueries
{
    public class GetAllSignaturesQuery : IRequest<IEnumerable<SignatureDetailedViewModel>>
    {
        public class GetAllSignaturesQueryHandler : IRequestHandler<GetAllSignaturesQuery, IEnumerable<SignatureDetailedViewModel>>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public GetAllSignaturesQueryHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<SignatureDetailedViewModel>> Handle(GetAllSignaturesQuery request, CancellationToken cancellationToken)
            {
                var signatures = await _dbContext.Set<Signature>().Include(x => x.Owner).ToListAsync();
                return _mapper.Map<IEnumerable<SignatureDetailedViewModel>>(signatures);
            }
        }
    }
}
