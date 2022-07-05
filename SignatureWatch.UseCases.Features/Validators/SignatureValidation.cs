using FluentValidation;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Features.Validators
{
    public class SignatureValidation : AbstractValidator<SignatureDTO>
    {
        public SignatureValidation()
        {
            RuleFor(x => x.SerialNumber)
                .NotEmpty().WithMessage("SerialNumber should not be empty");

            RuleFor(x => x.PublicKeyStartDate)
                .NotEmpty().WithMessage("PublicKeyStartDate should not be empty");

            RuleFor(x => x.PublicKeyEndDate)
                .NotEmpty().WithMessage("PublicKeyEndDate should not be empty");

            RuleFor(x => x.PrivateKeyStartDate)
                .NotEmpty().WithMessage("PrivateKeyStartDate should not be empty");

            RuleFor(x => x.PrivateKeyEndDate)
                .NotEmpty().WithMessage("PrivateKeyEndDate should not be empty");

            RuleFor(x => x.SignatureType)
                .IsInEnum().WithMessage("SerialNumber should not be empty");

            RuleFor(x => x.Owner)
                .NotEmpty().WithMessage("Owner should not be empty");
        }
    }
}
