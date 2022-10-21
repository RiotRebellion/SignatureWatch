using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.AccordanceSertificateCommands
{
    public class UpdateAccordanceSertificateCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }

        public AccordanceSertificateDTO AccordanceSertificateDTO { get; set; }

        public class UpdateAccordanceSertificateCommandHandler : IRequestHandler<UpdateAccordanceSertificateCommand, BaseResponse>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateAccordanceSertificateCommandHandler(IDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<BaseResponse> Handle(UpdateAccordanceSertificateCommand request, CancellationToken cancellationToken)
            {
                var existingAccordanceSertificate = _dbContext.Set<AccordanceSertificate>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (existingAccordanceSertificate == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данного сертификата не существует" }
                    };
                }
                else
                {
                    var accordanceSertificate = _mapper.Map<AccordanceSertificate>(request.AccordanceSertificateDTO);
                    existingAccordanceSertificate.RegNumber = accordanceSertificate.RegNumber;
                    existingAccordanceSertificate.AcquisitionDate = accordanceSertificate.AcquisitionDate;
                    existingAccordanceSertificate.ExpirationDate = accordanceSertificate.ExpirationDate;
                    existingAccordanceSertificate.ProlongDate = accordanceSertificate.ProlongDate;

                    var existingFormular = _dbContext.Set<Formular>()
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Guid == accordanceSertificate.FormularGuid);

                    if (existingFormular != null)
                    {
                        existingAccordanceSertificate.FormularGuid = existingFormular.Guid;
                    }

                    _dbContext.Set<AccordanceSertificate>().Update(existingAccordanceSertificate);
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
