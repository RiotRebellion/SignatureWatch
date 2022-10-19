using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SoftwareTypeCommands
{
    public class CreateSoftwareTypeCommand : IRequest<BaseResponse>
    {
        public SoftwareTypeDTO SoftwareTypeDTO { get; set; }

        public class CreateSoftwareTypeCommandHandler : IRequestHandler<CreateSoftwareTypeCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public CreateSoftwareTypeCommandHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(CreateSoftwareTypeCommand request, CancellationToken cancellationToken)
            {
                var softwareType = _mapper.Map<SoftwareType>(request.SoftwareTypeDTO);

                var existingSoftwareType = _dbContext.Set<SoftwareType>()
                    .FirstOrDefault(x => 
                    x.Name == softwareType.Name &&
                    x.SoftwareLocation == softwareType.SoftwareLocation);

                if (existingSoftwareType == null)
                {
                    _dbContext.Set<SoftwareType>().Add(softwareType);
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
                        Errors = new[] { "Данный тип ПО уже существует" }
                    };
                }
            }
        }
    }
}
