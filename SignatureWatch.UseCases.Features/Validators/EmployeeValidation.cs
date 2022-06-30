﻿using FluentValidation;
using SignatureWatch.UseCases.Contracts.DTO;

namespace SignatureWatch.UseCases.Features.Validators
{
    public class EmployeeValidation : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty");

            RuleFor(x => x.Department)
                .NotEmpty().WithMessage("Department should not be empty");

            RuleFor(x => x.EmployeeStatus)
                .NotEmpty().WithMessage("EmployeeStatus should not be empty");
        }
    }
}
