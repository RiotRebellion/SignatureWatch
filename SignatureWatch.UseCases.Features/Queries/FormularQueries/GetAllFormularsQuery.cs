using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.FormularQueries
{
    public class GetAllFormularsQuery : IRequest<IEnumerable<FormularViewModel>>
    {
        public class GetAllFormularsQueryHandler : IRequestHandler<GetAllFormularsQuery, IEnumerable<FormularViewModel>>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public GetAllFormularsQueryHandler(IDbContext dbContext, IMapper mapper)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<IEnumerable<FormularViewModel>> Handle(GetAllFormularsQuery request, CancellationToken cancellationToken)
            {
                var formulars = await _dbContext.Set<Formular>()
                    .Include(x => x.Distribution)
                    .ToListAsync();
                return _mapper.Map<IEnumerable<FormularViewModel>>(formulars);
            }
        }
    }
}
