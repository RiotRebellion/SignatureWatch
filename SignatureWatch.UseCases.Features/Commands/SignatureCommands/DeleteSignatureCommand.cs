using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public DeleteSignatureCommandHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(DeleteSignatureCommand request, CancellationToken cancellationToken)
            {
                var signature = await _dbContext.Set<Signature>()
                    .FirstOrDefaultAsync(x => x.Guid == request.Guid);

                if (signature == null)
                {
                    return await Task.FromResult(new BaseResponse
                    {
                        Errors = new[] { "Нечего удалять" }
                    });
                }
                _dbContext.Set<Signature>().Remove(signature);
                await _dbContext.SaveChangesAsync();
                return await Task.FromResult(new BaseResponse() { IsSuccess = true});
            }
        }
    }
}
