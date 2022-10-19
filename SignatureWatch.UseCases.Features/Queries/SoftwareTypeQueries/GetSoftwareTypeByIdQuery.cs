using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.SoftwareTypeQueries
{
    public class GetSoftwareTypeByIdQuery : IRequest<SoftwareTypeViewModel>
    {
        public Guid Guid { get; set; }

        public class GetSoftwareTypeByIdQueryHandler : IRequestHandler<GetSoftwareTypeByIdQuery, SoftwareTypeViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbcontext;

            public GetSoftwareTypeByIdQueryHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbcontext = dbContext;
            }

            public async Task<SoftwareTypeViewModel> Handle(GetSoftwareTypeByIdQuery query, CancellationToken cancellationToken)
            {
                var softwareType = await _dbcontext.Set<Domain.Entities.SoftwareType>()
                    .FirstOrDefaultAsync(x => x.Guid == query.Guid);
                return _mapper.Map<SoftwareTypeViewModel>(softwareType);
            }
        }
    }
}
