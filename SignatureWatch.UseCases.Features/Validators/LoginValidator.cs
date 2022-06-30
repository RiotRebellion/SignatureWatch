using FluentValidation;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Common.Utils;

namespace SignatureWatch.UseCases.Features.Validators
{
    public sealed class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator(StringUtil stringUtil)
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Введите логин")
                .Length(3, 16).WithMessage("Длина логина должа быть между 3 и 16")
                .Must(stringUtil.IsValueHasLettersOnly).WithMessage("Числа в логине недопустимы")
                .Matches("[A-Za_z]*").WithMessage("Допустимы только латинские символы");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Введите пароль");

            Transform(x => x.Username, stringUtil.ParseToLower);
        }
    }
}
