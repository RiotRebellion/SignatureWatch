using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.EmployeeCommands
{
    public class CreateEmployeeCommand : IRequest<BaseResponse>
    {
        public EmployeeDTO EmployeeDTO { get; set; } 

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public CreateEmployeeCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<BaseResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = _mapper.Map<Employee>(request.EmployeeDTO);

                var existingEmployee = _dbContext.Set<Employee>()
                    .FirstOrDefault(x => 
                    x.Name == employee.Name && 
                    x.Department == employee.Department &&
                    x.Post == employee.Post);

                if (existingEmployee == null)
                {
                    _dbContext.Set<Employee>().Add(employee);
                    await _dbContext.SaveChangesAsync();
                    return new BaseResponse { IsSuccess = true };
                }
                else
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Сотрудник с такими данными уже существует" }
                    };
                }
            }
        }
    }
}
