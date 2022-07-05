using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SignatureCommands
{
    public class UpdateSignatureCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }
        public SignatureDTO SignatureDTO { get; set; }

        public class UpdateSignatureCommandHandler : IRequestHandler<UpdateSignatureCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateSignatureCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<BaseResponse> Handle(UpdateSignatureCommand request, CancellationToken cancellationToken)
            {
                var existingSignature = await _dbContext.Set<Signature>()
                    .FirstOrDefaultAsync(x => x.Guid == request.Guid);

                if (existingSignature == null)
                    return await Task.FromResult(new BaseResponse
                    {
                        Errors = new[] { "Нету нихуя такого" }
                    });

                var signature = _mapper.Map<Signature>(request.SignatureDTO);
                signature.Guid = request.Guid;

                _dbContext.Set<Signature>().Update(signature);
                await _dbContext.SaveChangesAsync();
                return await Task.FromResult(new BaseResponse { IsSuccess = true });
            }
        }
    }
}
