using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Features.Common.Exceptions;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.EmployeeCommands
{
    public class UpdateEmployeeCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }
        public EmployeeDTO EmployeeDTO { get; set; }

        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateEmployeeCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<BaseResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var existingEmployee = await _dbContext.Set<Employee>()
                    .FirstOrDefaultAsync(x => x.Guid == request.Guid);

                if (existingEmployee == null)
                    return await Task.FromResult(new BaseResponse
                    {
                        Errors = new[] { "Нету нихуя такого" }
                    });

                var employee = _mapper.Map<Employee>(request.EmployeeDTO);
                employee.Guid = request.Guid;

                _dbContext.Set<Employee>().Update(employee);
                await _dbContext.SaveChangesAsync();
                return await Task.FromResult(new BaseResponse { IsSuccess = true }); 
            } 
        }
    }
}
