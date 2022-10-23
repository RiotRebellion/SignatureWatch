using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.SoftwareLicenseQueries
{
    public class GetSoftwareLicenseByIdQuery : IRequest<SoftwareLicenseViewModel>
    {
        public Guid Guid { get; set; }

        public class GetSoftwareLicenseByIdQueryHandler : IRequestHandler<GetSoftwareLicenseByIdQuery, SoftwareLicenseViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbcontext;

            public GetSoftwareLicenseByIdQueryHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbcontext = dbContext;
            }

            public async Task<SoftwareLicenseViewModel> Handle(GetSoftwareLicenseByIdQuery request, CancellationToken cancellationToken)
            {
                var softwareLicence = await _dbcontext.Set<SoftwareLicense>()
                    .Include(x => x.Contract)
                    .Include(x => x.Software)
                    .Include(x => x.Support)
                    .FirstOrDefaultAsync(x => x.Guid == request.Guid);

                return _mapper.Map<SoftwareLicenseViewModel>(softwareLicence);
            }
        }
    }
}
