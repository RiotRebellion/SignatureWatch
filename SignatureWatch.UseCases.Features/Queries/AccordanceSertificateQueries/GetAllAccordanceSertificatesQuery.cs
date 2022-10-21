using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.AccordanceSertificateQueries
{
    public class GetAllAccordanceSertificatesQuery : IRequest<IEnumerable<AccordanceSertificateViewModel>>
    {
        public class GetAllAccordanceSertificatesQueryHandler : IRequestHandler<GetAllAccordanceSertificatesQuery, IEnumerable<AccordanceSertificateViewModel>>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public GetAllAccordanceSertificatesQueryHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<AccordanceSertificateViewModel>> Handle(GetAllAccordanceSertificatesQuery request, CancellationToken cancellationToken)
            {
                var accordanceSertificate = await _dbContext.Set<AccordanceSertificate>()
                    .Include(x => x.Formular).ToListAsync();
                return _mapper.Map<IEnumerable<AccordanceSertificateViewModel>>(accordanceSertificate);
            }
        }
    }
}
