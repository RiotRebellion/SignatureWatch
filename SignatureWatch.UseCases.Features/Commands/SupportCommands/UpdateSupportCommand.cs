using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SupportCommands
{
    public class UpdateSupportCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }

        public SupportDTO SupportDTO { get; set; }

        public class UpdateSupportCommandHandler : IRequestHandler<UpdateSupportCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public UpdateSupportCommandHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(UpdateSupportCommand request, CancellationToken cancellationToken)
            {
                var existingSupport = _dbContext.Set<Support>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (existingSupport == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данная техподержка не существует" }
                    };
                }
                else
                {
                    var support = _mapper.Map<Support>(request.SupportDTO);
                    existingSupport.ActivationCode = support.ActivationCode;
                    existingSupport.Name = support.Name;
                    existingSupport.ExpirationDate = support.ExpirationDate;
                    existingSupport.PhoneNumber = support.PhoneNumber;
                    existingSupport.Email = support.Email;

                    _dbContext.Set<Support>().Update(existingSupport);
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
