using FluentValidation;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Features.Validators
{
    public class SoftwareTypeValidator : AbstractValidator<SoftwareTypeDTO>
    {
        public SoftwareTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty");

            RuleFor(x => x.SoftwareLocation)
                .IsInEnum().WithMessage("SoftwareLocation should not be empty");
        }
    }
}
