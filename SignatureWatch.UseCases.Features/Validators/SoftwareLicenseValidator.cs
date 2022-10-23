using FluentValidation;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Features.Validators
{
    public class SoftwareLicenseValidator : AbstractValidator<SoftwareLicenseDTO>
    {
        public SoftwareLicenseValidator()
        {
            RuleFor(x => x.LicenseNumber)
                .NotEmpty().WithMessage("LicenseNumber should not be empty");
            RuleFor(x => x.AcquisitionDate)
                .NotEmpty().WithMessage("AcquisitionDate should not be empty");
            RuleFor(x => x.ExpirationDate)
                .NotEmpty().WithMessage("ExpirationDate should not be empty");
            RuleFor(x => x.ContractGuid)
                .NotEmpty().WithMessage("Contract should not be empty");
            RuleFor(x => x.SoftwareGuid)
                .NotEmpty().WithMessage("Software should not be empty");
            RuleFor(x => x.SupportGuid)
               .NotEmpty().WithMessage("Support should not be empty");
        }
    }
}
