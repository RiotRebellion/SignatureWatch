using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SoftwareTypeCommands
{
    public class DeleteSoftwareTypeCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }

        public class DeleteSoftwareTypeCommandHandler : IRequestHandler<DeleteSoftwareTypeCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;

            public DeleteSoftwareTypeCommandHandler(IDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(DeleteSoftwareTypeCommand request, CancellationToken cancellationToken)
            {
                var existingSoftwareType = _dbContext.Set<SoftwareType>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (existingSoftwareType == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данный тип ПО не существует" }
                    };
                }
                else
                {
                    _dbContext.Set<SoftwareType>().Remove(existingSoftwareType);
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
