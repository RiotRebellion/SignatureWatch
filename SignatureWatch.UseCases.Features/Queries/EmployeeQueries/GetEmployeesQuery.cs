using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Queries.EmployeeQueries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDTO>>
    {
        public class GetAllEmployeesQueryHandle : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDTO>>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetAllEmployeesQueryHandle(IMapper mapper)
            {
                _dbContext = _dbContext;
                _mapper = mapper;
            }
                                                                                                        
            public async Task<IEnumerable<EmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
            {
                var employeeList = await _dbContext.Set<Employee>().ToListAsync();
                var result = _mapper.Map<IEnumerable<EmployeeDTO>>(employeeList);
                return result;
            }
        }
    }
}
