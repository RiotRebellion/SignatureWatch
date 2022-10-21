using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.AccordanceSertificateQueries
{
    public class GetAccordanceSertificateByIdQuery : IRequest<AccordanceSertificateViewModel>
    {
        public Guid Guid { get; set; }

        public class GetAccordanceSertificateByIdQueryHandler : IRequestHandler<GetAccordanceSertificateByIdQuery, AccordanceSertificateViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public GetAccordanceSertificateByIdQueryHandler (IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<AccordanceSertificateViewModel> Handle(GetAccordanceSertificateByIdQuery request, CancellationToken cancellationToken)
            {
                var accordanceSertificate = await _dbContext.Set<AccordanceSertificate>()
                    .Include(x => x.Formular)
                    .FirstOrDefaultAsync(x => x.Guid == request.Guid);
                return _mapper.Map<AccordanceSertificateViewModel>(accordanceSertificate);
            }
        }
    }
}
