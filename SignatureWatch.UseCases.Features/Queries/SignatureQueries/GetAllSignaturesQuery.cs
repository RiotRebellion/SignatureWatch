using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.SignatureQueries
{
    public class GetAllSignaturesQuery : IRequest<IEnumerable<SignatureViewModel>>
    {
        public class GetAllSignaturesQueryHandler : IRequestHandler<GetAllSignaturesQuery, IEnumerable<SignatureViewModel>>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public GetAllSignaturesQueryHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<SignatureViewModel>> Handle(GetAllSignaturesQuery request, CancellationToken cancellationToken)
            {
                var signatures = await _dbContext.Set<Signature>().Include(x => x.Owner).ToListAsync();
                var result = _mapper.Map<IEnumerable<SignatureViewModel>>(signatures);
                return result;
            }
        }
    }
}
