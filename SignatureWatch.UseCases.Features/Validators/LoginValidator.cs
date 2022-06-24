using FluentValidation;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Common.Utilities;

namespace SignatureWatch.UseCases.Features.Validators
{
    public sealed class LoginValidator : AbstractValidator<LoginDTO>
    {
        private readonly StringUtility _stringUtility;
        public LoginValidator()
        {
            RuleFor(x => x.Username)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введите логин")
                .Length(3, 16).WithMessage("Длина логина должа быть между 3 и 16")
                .Must(_stringUtility.IsValueHasLettersOnly).WithMessage("Числа в логине недопустимы")
                .Matches("[A-Za_z]*").WithMessage("Допустимы только латинские символы");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введите пароль");

            Transform(x => x.Username, _stringUtility.ParseToLower);
        }
    }
}
