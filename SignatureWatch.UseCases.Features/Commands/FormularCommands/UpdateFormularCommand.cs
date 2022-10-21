using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.FormularCommands
{
    public class UpdateFormularCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }
        public FormularDTO FormularDTO { get; set; }

        public class UpdateFormularCommandHandler : IRequestHandler<UpdateFormularCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateFormularCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<BaseResponse> Handle(UpdateFormularCommand request, CancellationToken cancellationToken)
            {
                var existingFormular = _dbContext.Set<Formular>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (existingFormular == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данного формуляра не существует" }
                    };
                }
                else
                {
                    var formular = _mapper.Map<Formular>(request.FormularDTO);
                    existingFormular.Name = formular.Name;
                    existingFormular.SerialKey = formular.SerialKey;
                    existingFormular.OrgRegNumber = formular.OrgRegNumber;
                    existingFormular.ProtectionKey = formular.ProtectionKey;

                    var existingDistribution = _dbContext.Set<Software>()
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Guid == formular.DistributionGuid);

                    if (existingDistribution != null)
                    {
                        existingFormular.DistributionGuid = existingDistribution.Guid;
                    }

                    _dbContext.Set<Formular>().Update(existingFormular);
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
