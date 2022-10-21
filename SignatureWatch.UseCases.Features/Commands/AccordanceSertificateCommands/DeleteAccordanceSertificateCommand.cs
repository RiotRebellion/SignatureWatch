using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.AccordanceSertificateCommands
{
    public class DeleteAccordanceSertificateCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }

        public class DeleteAccordanceSertificateCommandHandler : IRequestHandler<DeleteAccordanceSertificateCommand, BaseResponse>
        {
            private IDbContext _dbContext;

            public DeleteAccordanceSertificateCommandHandler(IDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(DeleteAccordanceSertificateCommand request, CancellationToken cancellationToken)
            {
                var existingAccordanceSertificate = _dbContext.Set<AccordanceSertificate>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (existingAccordanceSertificate == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] {"Данного сертификата не существует"}   
                    };
                }
                else
                {
                    _dbContext.Set<AccordanceSertificate>().Remove(existingAccordanceSertificate);
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
