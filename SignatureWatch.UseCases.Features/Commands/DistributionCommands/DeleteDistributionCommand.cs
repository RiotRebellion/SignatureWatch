using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.DistributionCommands
{
    public class DeleteDistributionCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }

        public class DeleteDistributionCommandHandler : IRequestHandler<DeleteDistributionCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;

            public DeleteDistributionCommandHandler(IDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(DeleteDistributionCommand request, CancellationToken cancellationToken)
            {
                var distribution = _dbContext.Set<Distribution>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (distribution == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данного дистрибутива не существует" }
                    };
                }
                else
                {
                    _dbContext.Set<Distribution>().Remove(distribution);
                    await _dbContext.SaveChangesAsync();
                    return new BaseResponse() { IsSuccess = true };
                }
            }
        }
    }
}
