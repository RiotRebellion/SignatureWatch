using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.EmployeeCommands
{
    public class DeleteEmployeeCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }

        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public DeleteEmployeeCommandHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = await _dbContext.Set<Employee>()
                    .FirstOrDefaultAsync(x => x.Guid == request.Guid);

                if (employee == null)
                {
                    return await Task.FromResult(new BaseResponse
                    {
                        Errors = new[] { "Нечего удалять" }
                    });
                }
                _dbContext.Set<Employee>().Remove(employee);
                await _dbContext.SaveChangesAsync();
                return await Task.FromResult(new BaseResponse() { IsSuccess = true});
            }
        }
    }
}
