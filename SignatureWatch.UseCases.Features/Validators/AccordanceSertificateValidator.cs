using FluentValidation;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Features.Validators
{
    public class AccordanceSertificateValidator : AbstractValidator<AccordanceSertificateDTO>
    {
        public AccordanceSertificateValidator()
        {
            RuleFor(x => x.RegNum)
                .NotEmpty().WithMessage("RegNum should not be empty");

            RuleFor(x => x.AcquisitionDate)
                .NotEmpty().WithMessage("AcquisitionDate should not be empty");

            RuleFor(x => x.ExpirationDate)
                .NotEmpty().WithMessage("ExpirationDate should not be empty");

            RuleFor(x => x.FormularGuid)
                .NotEmpty().WithMessage("FormularGuid should not be empty");
        }
    }
}
