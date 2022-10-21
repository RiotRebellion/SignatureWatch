using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SoftwareCommands
{
    public class CreateSoftwareCommand : IRequest<BaseResponse>
    {
        public SoftwareDTO SoftwareDTO;

        public class CreateSoftwareCommandHandler : IRequestHandler<CreateSoftwareCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public CreateSoftwareCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<BaseResponse> Handle(CreateSoftwareCommand request, CancellationToken cancellationToken)
            {
                var software = _mapper.Map<Software>(request.SoftwareDTO);

                var existingSoftwareType = _dbContext.Set<SoftwareType>()
                    .FirstOrDefault(x => x.Guid == software.SoftwareTypeGuid);

                if (existingSoftwareType == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Тип ПО не найден" }
                    };
                }

                var existingSoftware = _dbContext.Set<Software>()
                    .FirstOrDefault(x => 
                    x.Name == software.Name &&
                    x.Version == software.Version);

                if (existingSoftware == null)
                {
                    _dbContext.Set<Software>().Add(software);
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
                        Errors = new[] { "Данное ПО уже существует" }
                    };
                }

            }
        }
    }
}
