using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.DistributionCommands
{
    public class CreateDistributionCommand : IRequest<BaseResponse>
    {
        public DistributionDTO DistributionDTO { get; set; }

        public class CreateDistributionCommandHandler : IRequestHandler<CreateDistributionCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public CreateDistributionCommandHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(CreateDistributionCommand request, CancellationToken cancellationToken)
            {
                var distribution = _mapper.Map<Distribution>(request.DistributionDTO);

                var existingSoftware = _dbContext.Set<Software>()
                    .FirstOrDefault(x => x.Guid == distribution.SoftwareGuid);

                if (existingSoftware == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "ПО не найдено" }
                    };
                }

                var existingDistribution = _dbContext.Set<Distribution>()
                    .FirstOrDefault(x =>
                    x.Number == distribution.Number &&
                    x.OrgRegNumber == distribution.OrgRegNumber);

                if (existingDistribution == null)
                {
                    _dbContext.Set<Distribution>().Add(distribution);
                    await _dbContext.SaveChangesAsync();
                    return new BaseResponse { IsSuccess = true };
                }
                else
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данный дистрибутив уже существует" }
                    };
                }
            }
        }
    }
}
