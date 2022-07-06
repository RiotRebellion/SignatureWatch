using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.SignatureQueries
{
    public class GetSignatureByIdQuery : IRequest<SignatureDetailedViewModel>
    {
        public Guid Guid { get; set; }

        public class GetSignatureByIdQueryHandler : IRequestHandler<GetSignatureByIdQuery, SignatureDetailedViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbcontext;

            public GetSignatureByIdQueryHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbcontext = dbContext;
            }

            public async Task<SignatureDetailedViewModel> Handle(GetSignatureByIdQuery request, CancellationToken cancellationToken)
            {
                var employee = await _dbcontext.Set<Signature>()
                    .Include(x => x.Owner)
                    .FirstOrDefaultAsync(x => x.Guid == request.Guid);
                return _mapper.Map<SignatureDetailedViewModel>(employee);
            }
        }
    }
}
