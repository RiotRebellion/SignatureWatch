using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.SupportCommands
{
    public class CreateSupportCommand : IRequest<BaseResponse>
    {
        public SupportDTO SupportDTO { get; set; }

        public class CreateSupportCommandCommandHandler : IRequestHandler<CreateSupportCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public CreateSupportCommandCommandHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(CreateSupportCommand request, CancellationToken cancellationToken)
            {
                var support = _mapper.Map<Support>(request.SupportDTO);

                var existingSupport = _dbContext.Set<Support>()
                    .FirstOrDefault(x =>
                    x.ActivationCode == support.ActivationCode &&
                    x.Name == support.Name &&
                    x.ExpirationDate == support.ExpirationDate &&
                    x.PhoneNumber == support.PhoneNumber &&
                    x.Email == support.Email);

                if (existingSupport == null)
                {
                    _dbContext.Set<Support>().Add(support);
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
                        Errors = new[] { "Данная техподдержка уже существует" }
                    };
                }
            }
        }
    }
}
