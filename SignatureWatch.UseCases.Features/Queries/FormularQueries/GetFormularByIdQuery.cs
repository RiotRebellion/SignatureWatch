using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.FormularQueries
{
    public class GetFormularByIdQuery : IRequest<FormularViewModel>
    {
        public Guid Guid { get; set; }

        public class GetFormularByIdQueryHandler : IRequestHandler<GetFormularByIdQuery, FormularViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;
            public GetFormularByIdQueryHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<FormularViewModel> Handle(GetFormularByIdQuery request, CancellationToken cancellationToken)
            {
                var formular = await _dbContext.Set<Formular>()
                    .Include(x => x.Distribution)
                    .FirstOrDefaultAsync(x => x.Guid == request.Guid);
                return _mapper.Map<FormularViewModel>(formular);
            }
        }
    }
}
