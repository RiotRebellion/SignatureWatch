using FluentValidation;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Common.Utils;

namespace SignatureWatch.UseCases.Features.Validators
{
    public class RegistrationValidator : AbstractValidator<RegistrationDTO>
    {
        public RegistrationValidator(StringUtil stringUtil)
        {
            RuleFor(x => x.Username)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введите логин")
                .Length(3, 16).WithMessage("Длина логина должа быть между 3 и 16")
                .Must(stringUtil.IsValueHasLettersOnly).WithMessage("Числа в логине недопустимы")
                .Matches("[A-Za_z]*").WithMessage("Допустимы только латинские символы");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введите пароль")
                .Equal(x => x.ConfirmPassword);

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введите адрес почты")
                .EmailAddress().WithMessage("Это не почта!");

            Transform(x => x.Username, stringUtil.ParseToLower);
        }
    }
}
