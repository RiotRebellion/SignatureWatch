using FluentValidation;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Features.Validators
{
    public class DistributionValidator : AbstractValidator<DistributionDTO>
    {
        public DistributionValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Number should not be empty");
            RuleFor(x => x.OrgRegNumber)
                .NotEmpty().WithMessage("OrgRegNumber should not be empty");
            RuleFor(x => x.SoftwareGuid)
                .NotEmpty().WithMessage("Software should not be empty");
        }
    }
}
