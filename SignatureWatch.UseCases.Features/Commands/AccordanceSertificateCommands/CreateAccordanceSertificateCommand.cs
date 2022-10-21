using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.AccordanceSertificateCommands
{
    public class CreateAccordanceSertificateCommand : IRequest<BaseResponse>
    {
        public AccordanceSertificateDTO AccordanceSertificateDTO { get; set; }

        public class CreateAccordanceSertificateCommandHandler : IRequestHandler<CreateAccordanceSertificateCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public CreateAccordanceSertificateCommandHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(CreateAccordanceSertificateCommand request, CancellationToken cancellationToken)
            {
                var accordanceSertificate = _mapper.Map<AccordanceSertificate>(request.AccordanceSertificateDTO);

                var existingFormular = _dbContext.Set<Formular>()
                    .FirstOrDefault(x => x.Guid == accordanceSertificate.FormularGuid);

                if (existingFormular == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данного формуляра не найдено" }
                    };
                }

                var existingAccordanceSertificate = _dbContext.Set<AccordanceSertificate>()
                    .FirstOrDefault(x => x.RegNumber == accordanceSertificate.RegNumber);
                
                if (existingAccordanceSertificate == null)
                {
                    _dbContext.Set<AccordanceSertificate>().Add(accordanceSertificate);
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
                        Errors = new[] { "Данный сертификат уже существует" }
                    };
                }
                
            }
        }
    }
}
