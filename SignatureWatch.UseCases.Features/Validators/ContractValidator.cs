using FluentValidation;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Features.Validators
{
    public class ContractValidator : AbstractValidator<ContractDTO>
    {
        public ContractValidator()
        {
            RuleFor(x => x.ContractName)
                .NotEmpty().WithMessage("ContractName should not be empty");
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date should not be empty");
        }
    }
}
