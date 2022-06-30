using MediatR;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Features.Commands.SignatureCommand
{
    public class CreateSignatureCommand : IRequest<int>
    {
        public SignatureDTO SignatureDTO;

        public class CreateSignatureCommandHandler : IRequestHandler<CreateSignatureCommand, int>
        {
            public async Task<int> Handle(CreateSignatureCommand command, CancellationToken cancellationToken)
            {
                var signature = 
            }
        }
    }
}
