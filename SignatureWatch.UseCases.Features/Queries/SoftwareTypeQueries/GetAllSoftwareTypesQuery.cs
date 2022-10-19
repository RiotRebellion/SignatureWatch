using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.SoftwareTypeQueries
{
    public class GetAllSoftwareTypesQuery : IRequest<IEnumerable<SoftwareTypeViewModel>>
    {
        public class GetAllSoftwareTypesQueryHandler : IRequestHandler<GetAllSoftwareTypesQuery, IEnumerable<SoftwareTypeViewModel>>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetAllSoftwareTypesQueryHandler(IMapper mapper, IDbContext dbContext)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<SoftwareTypeViewModel>> Handle(GetAllSoftwareTypesQuery query, CancellationToken cancellationToken)
            {
                var softwareTypeList = await _dbContext.Set<SoftwareType>().ToListAsync();
                return _mapper.Map<IEnumerable<SoftwareTypeViewModel>>(softwareTypeList);
            }
        }
    }
}
