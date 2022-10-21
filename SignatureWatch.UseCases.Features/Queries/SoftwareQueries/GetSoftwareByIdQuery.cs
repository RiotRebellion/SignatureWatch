using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.SoftwareQueries
{
    public class GetSoftwareByIdQuery : IRequest<SoftwareViewModel>
    {
        public Guid Guid { get; set; }

        public class GetSoftwareByIdQueryHandler : IRequestHandler<GetSoftwareByIdQuery, SoftwareViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbcontext;

            public GetSoftwareByIdQueryHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbcontext = dbContext;
            }

            public async Task<SoftwareViewModel> Handle(GetSoftwareByIdQuery request, CancellationToken cancellationToken)
            {
                var software = await _dbcontext.Set<Software>()
                    .Include(x => x.SoftwareType)
                    .Include(x => x.Distribution)
                    .FirstOrDefaultAsync(x => x.Guid == request.Guid);
                return _mapper.Map<SoftwareViewModel>(software);
            }
        }
    }
}
