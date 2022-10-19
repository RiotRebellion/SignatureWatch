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
                var existingSignature = _dbContext.Set<Signature>()
                    .Include(x => x.Owner)
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (existingSignature == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Нет такого" }
                    };
                }
                else
                {
                    var data = _mapper.Map<Signature>(request.SignatureDTO);

                    existingSignature.SerialNumber = data.SerialNumber;
                    existingSignature.PublicKeyStartDate = data.PublicKeyStartDate;
                    existingSignature.PublicKeyEndDate = data.PublicKeyEndDate;
                    existingSignature.PrivateKeyStartDate = data.PrivateKeyStartDate;
                    existingSignature.PrivateKeyEndDate = data.PrivateKeyEndDate;

                    var existingEmployee = _dbContext.Set<Employee>()
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Guid == data.OwnerGuid);

                    if (existingEmployee != null)
                    {
                        existingSignature.OwnerGuid = existingEmployee.Guid;
                    }

                    _dbContext.Set<Signature>().Update(existingSignature);
                    await _dbContext.SaveChangesAsync();
                    return new BaseResponse { IsSuccess = true };
                }            
            }
        }
    }
}
