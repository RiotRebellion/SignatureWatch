using FluentValidation;
using SignatureWatch.UseCases.Contracts.ViewModels;

namespace SignatureWatch.UseCases.Features.Validators
{
    public class EmployeeValidation :AbstractValidator<EmployeeViewModel>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Заполните имя сотрудника");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Заполните фамилию сотрудника");

            RuleFor(x => x.Department)
                .NotEmpty().WithMessage("Заполните отдел сотрудника");
        }
    }
}
