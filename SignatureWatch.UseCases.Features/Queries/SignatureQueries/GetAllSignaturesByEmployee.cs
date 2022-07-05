using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.SignatureQueries
{
    public class GetAllSignaturesByEmployee : IRequest<IEnumerable<SignatureViewModel>>
    {
        public Guid Guid { get; set; }

        public class GetAllSignaturesByEmployeeHandler : IRequestHandler<GetAllSignaturesByEmployee, IEnumerable<SignatureViewModel>>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public GetAllSignaturesByEmployeeHandler(IMapper mapper, IDbContext dbContext)
            {
                (_mapper, _dbContext) = (mapper, dbContext);
            }

            public async Task<IEnumerable<SignatureViewModel>> Handle(GetAllSignaturesByEmployee request, CancellationToken cancellationToken)
            {
                var result = await _dbContext.Set<Signature>()
                    .Where(x => x.OwnerId == request.Guid)
                    .ToListAsync();

                return _mapper.Map<IEnumerable<SignatureViewModel>>(result);
            }
        }
    }
}
