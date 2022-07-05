using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.EmployeeQueries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeViewModel>>
    {
        public class GetAllEmployeesQueryHandle : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeViewModel>>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetAllEmployeesQueryHandle(IMapper mapper, IDbContext dbContext)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
                                                                                                        
            public async Task<IEnumerable<EmployeeViewModel>> Handle(GetAllEmployeesQuery query, CancellationToken cancellationToken)
            {
                var employeeList = await _dbContext.Set<Employee>().ToListAsync();
                var result = _mapper.Map<IEnumerable<EmployeeViewModel>>(employeeList);
                return result;
            }
        }
    }
}
