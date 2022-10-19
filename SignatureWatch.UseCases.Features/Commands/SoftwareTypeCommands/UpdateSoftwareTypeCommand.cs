using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SoftwareTypeCommands
{
    public class UpdateSoftwareTypeCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }

        public SoftwareTypeDTO SoftwareTypeDTO { get; set; }

        public class UpdateSoftwareTypeCommandHandler : IRequestHandler<UpdateSoftwareTypeCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public UpdateSoftwareTypeCommandHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(UpdateSoftwareTypeCommand request, CancellationToken cancellationToken)
            {
                var existingSoftwareType = _dbContext.Set<SoftwareType>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (existingSoftwareType == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данный тип ПО не существует" }
                    };
                }
                else
                {
                    var softwareType = _mapper.Map<SoftwareType>(request.SoftwareTypeDTO);
                    existingSoftwareType.Name = softwareType.Name;
                    existingSoftwareType.SoftwareLocation = softwareType.SoftwareLocation;

                    _dbContext.Set<SoftwareType>().Update(existingSoftwareType);
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
