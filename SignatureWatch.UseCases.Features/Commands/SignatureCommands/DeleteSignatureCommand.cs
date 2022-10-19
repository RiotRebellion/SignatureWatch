using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SignatureCommands
{
    public class DeleteSignatureCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }

        public class DeleteSignatureCommandHandler : IRequestHandler<DeleteSignatureCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;

            public DeleteSignatureCommandHandler(IDbContext dbContext)
            { 
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(DeleteSignatureCommand request, CancellationToken cancellationToken)
            {
                var signature = _dbContext.Set<Signature>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (signature == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Нечего удалять" }
                    };
                }
                else
                {
                    _dbContext.Set<Signature>().Remove(signature);
                    await _dbContext.SaveChangesAsync();
                    return new BaseResponse() { IsSuccess = true };
                }
            }
        }
    }
}
