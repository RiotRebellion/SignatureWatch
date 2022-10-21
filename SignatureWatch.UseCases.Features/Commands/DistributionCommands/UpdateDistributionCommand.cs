using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.DistributionCommands
{
    public class UpdateDistributionCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }
        public DistributionDTO DistributionDTO { get; set; }

        public class UpdateDistributionCommandHandler : IRequestHandler<UpdateDistributionCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateDistributionCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<BaseResponse> Handle(UpdateDistributionCommand request, CancellationToken cancellationToken)
            {
                var existingDistribution = _dbContext.Set<Distribution>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (existingDistribution == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данного дистрибутива не существует" }
                    };
                }
                else
                {
                    var distribution = _mapper.Map<Distribution>(request.DistributionDTO);
                    existingDistribution.Number = distribution.Number;
                    existingDistribution.OrgRegNumber = distribution.OrgRegNumber;

                    var existingSoftware = _dbContext.Set<Software>()
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Guid == distribution.SoftwareGuid);

                    if (existingSoftware != null)
                    {
                        existingDistribution.SoftwareGuid = existingSoftware.Guid;
                    }

                    _dbContext.Set<Distribution>().Update(existingDistribution);
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
