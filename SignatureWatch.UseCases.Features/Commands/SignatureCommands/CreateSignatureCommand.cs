using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SignatureCommands
{
    public class CreateSignatureCommand : IRequest<BaseResponse>
    {
        public SignatureDTO SignatureDTO;

        public class CreateSignatureCommandHandler : IRequestHandler<CreateSignatureCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public CreateSignatureCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<BaseResponse> Handle(CreateSignatureCommand request, CancellationToken cancellationToken)
            {
                var signature = _mapper.Map<Signature>(request.SignatureDTO);

                //Проверка существования пользователя
                var existingEmployee = await _dbContext.Set<Employee>()
                    .FirstOrDefaultAsync(x =>
                        x.Name == signature.Owner.Name &&
                        x.Department == signature.Owner.Department);

                if (existingEmployee == null)
                {
                    await _dbContext.Set<Employee>().AddAsync(signature.Owner);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    signature.OwnerId = existingEmployee.Guid;
                    signature.Owner = null;
                }

                //проверка существования подписи
                var existingSignature = await _dbContext.Set<Signature>()
                    .FirstOrDefaultAsync(x =>
                        x.SerialNumber == signature.SerialNumber);

                if (existingSignature == null)
                {
                    await _dbContext.Set<Signature>().AddAsync(signature);
                    await _dbContext.SaveChangesAsync();

                    return await Task.FromResult(new BaseResponse
                    {
                        IsSuccess = true
                    });
                }

                return await Task.FromResult(new BaseResponse
                {
                    Errors = new[] {"Подпись уже существует"}
                });
            }
        }
    }
}
