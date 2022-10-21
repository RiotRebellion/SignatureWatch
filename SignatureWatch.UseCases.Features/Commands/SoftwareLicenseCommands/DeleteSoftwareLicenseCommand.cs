using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SoftwareLicenseCommands
{
    public class DeleteSoftwareLicenseCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }

        public class DeleteSoftwareLicenseCommandHandler : IRequestHandler<DeleteSoftwareLicenseCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;

            public DeleteSoftwareLicenseCommandHandler(IDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(DeleteSoftwareLicenseCommand request, CancellationToken cancellationToken)
            {
                var softwareLicense = _dbContext.Set<SoftwareLicense>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (softwareLicense == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данного ключа активации ПО не существует" }
                    };
                }
                else
                {
                    _dbContext.Set<SoftwareLicense>().Remove(softwareLicense);
                    await _dbContext.SaveChangesAsync();
                    return new BaseResponse() { IsSuccess = true };
                }
            }
        }
    }
}
