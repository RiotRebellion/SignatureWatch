using FluentValidation;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Features.Validators
{
    public class SupportValidator : AbstractValidator<SupportDTO>
    {
        public SupportValidator()
        {
            RuleFor(x => x.ActivationCode)
                .NotEmpty().WithMessage("ActivationCode should not be empty");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty");

            RuleFor(x => x.ExpirationDate)
                .NotEmpty().WithMessage("ExpirationDate should not be empty");
        }
    }
}
