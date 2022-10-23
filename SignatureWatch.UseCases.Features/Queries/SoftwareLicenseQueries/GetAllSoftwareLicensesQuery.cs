using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.SoftwareLicenseQueries
{
    public class GetAllSoftwareLicensesQuery : IRequest<IEnumerable<SoftwareLicenseViewModel>>
    {
        public class GetAllSoftwareLicensesQueryHandler : IRequestHandler<GetAllSoftwareLicensesQuery, IEnumerable<SoftwareLicenseViewModel>>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public GetAllSoftwareLicensesQueryHandler(IMapper mapper, IDbContext dbContext)
            {
                (_mapper, _dbContext) = (mapper, dbContext);
            }

            public async Task<IEnumerable<SoftwareLicenseViewModel>> Handle(GetAllSoftwareLicensesQuery request, CancellationToken cancellationToken)
            {
                var softwareLicenses = await _dbContext.Set<SoftwareLicense>()
                    .Include(x => x.Contract)
                    .Include(x => x.Software)
                    .Include(x => x.Support)
                    .ToListAsync();

                return _mapper.Map<IEnumerable<SoftwareLicenseViewModel>>(softwareLicenses);
            }
        }
    }
}
