using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.ContractCommands
{
    public class DeleteContractCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }

        public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;

            public DeleteContractCommandHandler(IDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
            {
                var existingContract = _dbContext.Set<Contract>()
                    .FirstOrDefault(x => x.Guid == request.Guid);
                
                if(existingContract == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данного контракта не существует" }
                    };
                }
                else
                {
                    _dbContext.Set<Contract>().Remove(existingContract);
                    await _dbContext.SaveChangesAsync();
                    return new BaseResponse
                    {
                        IsSuccess = true
                    };
                }
            }
        }
    }
}
