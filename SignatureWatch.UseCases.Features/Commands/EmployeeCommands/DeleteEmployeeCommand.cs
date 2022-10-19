using MediatR;
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
            private readonly IDbContext _dbContext;

            public DeleteEmployeeCommandHandler(IDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = _dbContext.Set<Employee>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (employee == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Нечего удалять" }
                    };
                }
                _dbContext.Set<Employee>().Remove(employee);
                await _dbContext.SaveChangesAsync();
                return new BaseResponse() { IsSuccess = true};
            }
        }
    }
}
