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
                    .Include(x => x.Owner)
                    .Where(x => x.Guid == request.Guid)
                    .FirstOrDefaultAsync();

                if (existingSignature == null)
                {
                    return await Task.FromResult(new BaseResponse
                    {
                        Errors = new[] { "Нет такого" }
                    });
                }

                var data = _mapper.Map<Signature>(request.SignatureDTO);

                existingSignature.SerialNumber = data.SerialNumber;
                existingSignature.PublicKeyStartDate = data.PublicKeyStartDate;
                existingSignature.PublicKeyEndDate = data.PublicKeyEndDate;
                existingSignature.PrivateKeyStartDate = data.PrivateKeyStartDate;
                existingSignature.PrivateKeyEndDate = data.PrivateKeyEndDate;

                var existingEmployee = await _dbContext.Set<Employee>()
                    .AsNoTracking()
                    .Where(x => x.Name == data.Owner.Name &&
                        x.Department == data.Owner.Department &&
                        x.Post == data.Owner.Post)
                    .FirstOrDefaultAsync();

                if (existingEmployee != null)
                {
                    existingSignature.OwnerId = existingEmployee.Guid;
                }

                _dbContext.Set<Signature>().Update(existingSignature);
                await _dbContext.SaveChangesAsync();
                return await Task.FromResult(new BaseResponse { IsSuccess = true });
            }
        }
    }
}
