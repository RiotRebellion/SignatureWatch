using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Features.Common.Exceptions;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.EmployeeQueries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeViewModel>
    {
        public Guid Guid { get; set; }

        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbcontext;

            public GetEmployeeByIdQueryHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbcontext = dbContext;
            }

            public async Task<EmployeeViewModel> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
            {
                var employee = await _dbcontext.Set<Employee>()
                    .FirstOrDefaultAsync(x => x.Guid == query.Guid);
                return _mapper.Map<EmployeeViewModel>(employee);
            }
        }
    }
}
