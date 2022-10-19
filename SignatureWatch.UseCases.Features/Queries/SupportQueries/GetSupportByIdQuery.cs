using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.SupportQueries
{
    public class GetSupportByIdQuery : IRequest<SupportViewModel>
    {
        public Guid Guid { get; set; }

        public class GetSupportByIdQueryHandler : IRequestHandler<GetSupportByIdQuery, SupportViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbcontext;

            public GetSupportByIdQueryHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbcontext = dbContext;
            }

            public async Task<SupportViewModel> Handle(GetSupportByIdQuery query, CancellationToken cancellationToken)
            {
                var support = await _dbcontext.Set<Support>()
                    .FirstOrDefaultAsync(x => x.Guid == query.Guid);
                return _mapper.Map<SupportViewModel>(support);
            }
        }
    }
}
