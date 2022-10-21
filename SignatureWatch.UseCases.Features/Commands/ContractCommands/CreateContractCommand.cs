using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.ContractCommands
{
    public class CreateContractCommand : IRequest<BaseResponse>
    {
        public ContractDTO ContractDTO { get; set; }

        public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public CreateContractCommandHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(CreateContractCommand request, CancellationToken cancellationToken)
            {
                var contract = _mapper.Map<Contract>(request.ContractDTO);

                var existingContract = _dbContext.Set<Contract>()
                    .FirstOrDefault(x => x.ContractNumber == contract.ContractNumber);

                if (existingContract == null)
                {
                    _dbContext.Set<Contract>().Add(contract);
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
                        Errors = new[] { "Данный контракт уже существует" }
                    };
                }
            }
        }
    }
}
