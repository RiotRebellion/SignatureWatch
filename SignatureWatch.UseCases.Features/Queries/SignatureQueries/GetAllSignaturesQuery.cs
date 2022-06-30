using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.SignatureQueries
{
    public class GetAllSignaturesQuery : IRequest<IEnumerable<SignatureDTO>>
    {
        public class GetAllSignaturesQueryHandler : IRequestHandler<GetAllSignaturesQuery, IEnumerable<SignatureDTO>>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public GetAllSignaturesQueryHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<SignatureDTO>> Handle(GetAllSignaturesQuery request, CancellationToken cancellationToken)
            {
                var signatures = await _dbContext.Set<Signature>().ToListAsync();
                var result = _mapper.Map<IEnumerable<SignatureDTO>>(signatures);
                return result;
            }
        }
    }
}
