using FluentValidation;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Features.Validators
{
    public class FormularValidator : AbstractValidator<FormularDTO>
    {
        public FormularValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty");
            RuleFor(x => x.SerialKey)
                .NotEmpty().WithMessage("SerialKey should not be empty");
            RuleFor(x => x.OrgRegNumber)
                .NotEmpty().WithMessage("OrgRegNumber should not be empty");
            RuleFor(x => x.ProtectionKey)
                .NotEmpty().WithMessage("ProtectionKey should not be empty");
            RuleFor(x => x.DistributionGuid)
                .NotEmpty().WithMessage("DistributionGuid should not be empty");
        }
    }
}
