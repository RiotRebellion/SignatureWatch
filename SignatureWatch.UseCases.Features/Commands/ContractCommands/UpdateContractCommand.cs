using AutoMapper;
using MediatR;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Contracts.Responses.Base;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.UseCases.Features.Commands.ContractCommands
{
    public class UpdateContractCommand : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }

        public ContractDTO ContractDTO { get; set; }

        public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, BaseResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _dbContext;

            public UpdateContractCommandHandler(IMapper mapper, IDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<BaseResponse> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
            {
                var existingContract = _dbContext.Set<Contract>()
                    .FirstOrDefault(x => x.Guid == request.Guid);

                if (existingContract == null)
                {
                    return new BaseResponse
                    {
                        Errors = new[] { "Данного контракта не существует" }
                    };
                }
                else
                {
                    var contract = _mapper.Map<Contract>(request.ContractDTO);
                    existingContract.ContractNumber = contract.ContractNumber;
                    existingContract.Date = contract.Date;

                    _dbContext.Set<Contract>().Update(existingContract);
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
