using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SoftwareLicenseCommands
{
    public class UpdateSoftwareLicenseCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }
        public SoftwareLicenseDTO SoftwareLicenseDTO { get; set; }

        public class UpdateSoftwareLicenseCommandHandler : IRequestHandler<UpdateSoftwareLicenseCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateSoftwareLicenseCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<BaseResponse> Handle(UpdateSoftwareLicenseCommand request, CancellationToken cancellationToken)
            {
                var existingSoftwareLicense = _dbContext.Set<SoftwareLicense>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (existingSoftwareLicense == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данный ключ активации ПО не существует" }
                    };
                }
                else
                {
                    var softwareLicense = _mapper.Map<SoftwareLicense>(request.SoftwareLicenseDTO);
                    existingSoftwareLicense.LicenseNumber = softwareLicense.LicenseNumber;
                    existingSoftwareLicense.AcquisitionDate = softwareLicense.AcquisitionDate;
                    existingSoftwareLicense.ExpirationDate = softwareLicense.ExpirationDate;

                    var existingContract = _dbContext.Set<Contract>()
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Guid == softwareLicense.ContractGuid);

                    if (existingContract != null)
                    {
                        existingSoftwareLicense.ContractGuid = existingContract.Guid;
                    }

                    var existingSoftware = _dbContext.Set<Software>()
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Guid == softwareLicense.SoftwareGuid);

                    if (existingSoftware != null)
                    {
                        existingSoftwareLicense.SoftwareGuid = existingSoftware.Guid;
                    }

                    var existingSupport = _dbContext.Set<Support>()
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Guid == softwareLicense.SupportGuid);

                    if (existingSupport != null)
                    {
                        existingSoftwareLicense.SupportGuid = existingSupport.Guid;
                    }

                    _dbContext.Set<SoftwareLicense>().Update(existingSoftwareLicense);
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
