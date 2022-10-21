using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.FormularCommands
{
    public class DeleteFormularCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }

        public class DeleteFormularCommandHandler : IRequestHandler<DeleteFormularCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;

            public DeleteFormularCommandHandler(IDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(DeleteFormularCommand request, CancellationToken cancellationToken)
            {
                var formular = _dbContext.Set<Formular>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (formular == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данного формуляра не существует" }
                    };
                }
                else
                {
                    _dbContext.Set<Formular>().Remove(formular);
                    await _dbContext.SaveChangesAsync();
                    return new BaseResponse() { IsSuccess = true };
                }
            }
        }
    }
}
