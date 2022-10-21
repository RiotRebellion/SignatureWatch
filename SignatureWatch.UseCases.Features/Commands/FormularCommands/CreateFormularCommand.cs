using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.FormularCommands
{
    public class CreateFormularCommand : IRequest<BaseResponse>
    {
        public FormularDTO FormularDTO { get; set; }

        public class CreateFormularCommandHandler : IRequestHandler<CreateFormularCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public CreateFormularCommandHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(CreateFormularCommand request, CancellationToken cancellationToken)
            {
                var formular = _mapper.Map<Formular>(request.FormularDTO);

                var existingDistribution = _dbContext.Set<Distribution>()
                    .FirstOrDefault(x => x.Guid == formular.DistributionGuid);

                if (existingDistribution == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Дистрибутив не найден" }
                    };
                }

                var existingFormular = _dbContext.Set<Formular>()
                    .FirstOrDefault(x =>
                    x.Name == formular.Name &&
                    x.SerialKey == formular.SerialKey &&
                    x.OrgRegNumber == formular.OrgRegNumber &&
                    x.ProtectionKey == formular.ProtectionKey);

                if (existingFormular == null)
                {
                    _dbContext.Set<Formular>().Add(formular);
                    await _dbContext.SaveChangesAsync();
                    return new BaseResponse { IsSuccess = true };
                }
                else
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данный формуляр уже существует" }
                    };
                }
            }
        }
    }
}
