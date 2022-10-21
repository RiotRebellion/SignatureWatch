using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SoftwareCommands
{
    public class UpdateSoftwareCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }
        public SoftwareDTO SoftwareDTO { get; set; }

        public class UpdateSoftwareCommandHandler : IRequestHandler<UpdateSoftwareCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateSoftwareCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<BaseResponse> Handle(UpdateSoftwareCommand request, CancellationToken cancellationToken)
            {
                var existingSoftware = _dbContext.Set<Software>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (existingSoftware == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данное ПО не существует" }
                    };
                }
                else
                {
                    var software = _mapper.Map<Software>(request.SoftwareDTO);
                    existingSoftware.Name = software.Name;
                    existingSoftware.Version = software.Version;

                    var existingSoftwareType = _dbContext.Set<SoftwareType>()
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Guid == software.SoftwareTypeGuid);

                    if (existingSoftwareType != null)
                    {
                        existingSoftware.SoftwareTypeGuid = existingSoftwareType.Guid;
                    }

                    _dbContext.Set<Software>().Update(existingSoftware);
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
