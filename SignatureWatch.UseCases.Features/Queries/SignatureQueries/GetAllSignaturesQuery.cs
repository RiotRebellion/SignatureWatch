using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
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

            public GetAllSignaturesQueryHandler(IMapper mapper, IDbContext dbContext)
            {
                (_mapper, _dbContext) = (mapper, dbContext);
            }
            
            public async Task<IEnumerable<SignatureViewModel>> Handle(GetAllSignaturesQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<Signature> signatureList = await _dbContext.Set<Signature>().ToListAsync();
                var result = _mapper.Map<IEnumerable<Signature>, IEnumerable<SignatureViewModel>>(signatureList);
                return result;
            }
        }
    }
}
