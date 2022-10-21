using FluentValidation;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Features.Validators
{
    public class SoftwareValidator : AbstractValidator<SoftwareDTO>
    {
        public SoftwareValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty");

            RuleFor(x => x.Version)
                .NotEmpty().WithMessage("Version should not be empty");

            RuleFor(x => x.SoftwareTypeGuid)
                .NotEmpty().WithMessage("SoftwareTypeGuid should not be empty");
        }
    }
}
