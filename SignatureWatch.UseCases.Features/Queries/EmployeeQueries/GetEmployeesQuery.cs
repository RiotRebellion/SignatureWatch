using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.EmployeeQueries
{
    public class GetEmployeesQuery : IRequest<IEnumerable<EmployeeViewModel>>
    {
        public class GetEmployeesQueryHandle : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeViewModel>>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetEmployeesQueryHandle(IMapper mapper)
            {
                _dbContext = _dbContext;
                _mapper = mapper;
            }
                                                                                                        
            public async Task<IEnumerable<EmployeeViewModel>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<Employee> signatureList = await _dbContext.Set<Employee>().ToListAsync();
                var result = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(signatureList);
                return result;
            }
        }
    }
}
