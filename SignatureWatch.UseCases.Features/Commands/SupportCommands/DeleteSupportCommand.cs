using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SupportCommands
{
    public class DeleteSupportCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }

        public class DeleteSupportCommandHandler : IRequestHandler<DeleteSupportCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;

            public DeleteSupportCommandHandler(IDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(DeleteSupportCommand request, CancellationToken cancellationToken)
            {
                var existingSupport = _dbContext.Set<Support>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (existingSupport == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данный тип ПО не существует" }
                    };
                }
                else
                {
                    _dbContext.Set<Support>().Remove(existingSupport);
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
