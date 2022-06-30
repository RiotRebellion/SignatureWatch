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
        public EmployeeDTO EmployeeDTO;

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public CreateEmployeeCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<BaseResponse> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
            {
                var employee = _mapper.Map<Employee>(command.EmployeeDTO);

                var existingEmployee = await _dbContext.Set<Employee>()
                    .FirstOrDefaultAsync(x => x.Name == employee.Name && x.Department == x.Department);

                if (existingEmployee == null)
                {
                    await _dbContext.Set<Employee>().AddAsync(employee);
                    return await Task.FromResult(new BaseResponse { IsSuccess = true });
                }
                return await Task.FromResult(new BaseResponse
                {
                    Errors = new[] { "Сотрудник с такими данными уже существует" }
                });
            }
        }
    }
}
