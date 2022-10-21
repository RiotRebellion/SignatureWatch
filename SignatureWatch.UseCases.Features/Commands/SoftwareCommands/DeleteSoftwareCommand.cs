using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SoftwareCommands
{
    public class DeleteSoftwareCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }

        public class DeleteSoftwareCommandHandler : IRequestHandler<DeleteSoftwareCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;

            public DeleteSoftwareCommandHandler(IDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(DeleteSoftwareCommand request, CancellationToken cancellationToken)
            {
                var software = _dbContext.Set<Software>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (software == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данного ПО не существует" }
                    };
                }
                else
                {
                    _dbContext.Set<Software>().Remove(software);
                    await _dbContext.SaveChangesAsync();
                    return new BaseResponse() { IsSuccess = true };
                }
            }
        }
    }
}
