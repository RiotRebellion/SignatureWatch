using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SoftwareLicenseCommands
{
    public class CreateSoftwareLicenseCommand : IRequest<BaseResponse>
    {
        public SoftwareLicenseDTO SoftwareLicenseDTO;

        public class CreateSoftwareLicenseCommandHandler : IRequestHandler<CreateSoftwareLicenseCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public CreateSoftwareLicenseCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<BaseResponse> Handle(CreateSoftwareLicenseCommand request, CancellationToken cancellationToken)
            {
                var softwareLicense = _mapper.Map<SoftwareLicense>(request.SoftwareLicenseDTO);

                var existingContract = _dbContext.Set<Contract>()
                    .FirstOrDefault(x => x.Guid == softwareLicense.ContractGuid);

                if (existingContract == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Контракт не найден" }
                    };
                }

                var existingSoftware = _dbContext.Set<Software>()
                    .FirstOrDefault(x => x.Guid == softwareLicense.SoftwareGuid);

                if (existingSoftware == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "ПО не найдено" }
                    };
                }

                var existingsoftwareLicense = _dbContext.Set<SoftwareLicense>()
                    .FirstOrDefault(x => x.LicenseNumber == softwareLicense.LicenseNumber);

                if (existingsoftwareLicense == null)
                {
                    _dbContext.Set<SoftwareLicense>().Add(softwareLicense);
                    await _dbContext.SaveChangesAsync();

                    return new BaseResponse
                    {
                        IsSuccess = true
                    };
                }
                else
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данный ключ активации ПО уже существует" }
                    };
                }

            }
        }
    }
}
