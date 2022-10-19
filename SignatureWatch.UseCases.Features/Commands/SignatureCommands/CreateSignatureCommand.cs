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
                var existingEmployee = _dbContext.Set<Employee>()
                    .FirstOrDefault(x => x.Guid == signature.OwnerGuid);

                if(existingEmployee == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] {"Такого пользователя не найдено"}
                    };
                }

                //проверка существования подписи
                var existingSignature = _dbContext.Set<Signature>()
                    .FirstOrDefault(x => x.SerialNumber == signature.SerialNumber);

                if (existingSignature == null)
                {
                    _dbContext.Set<Signature>().Add(signature);
                    await _dbContext.SaveChangesAsync();

                    return new BaseResponse
                    {
                        IsSuccess = true
                    };
                }

                return new BaseResponse
                {
                    Errors = new[] {"Подпись уже существует"}
                };
            }
        }
    }
}
