using System.ComponentModel.DataAnnotations;

namespace SignatureWatch.UseCases.Contracts.DTO
{
    public class RegistrationDTO
    {
        [Display(Name = "Имя пользователя")]
        [Required(ErrorMessage = "Заполните имя пользователя")]
        [RegularExpression(@"^\p{L}$", ErrorMessage = "Неподходящие символы")]
        public string Username { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Заполните пароль")]
        public string Password { get; set; }

        [Display(Name = "Подтверждение пароля")]
        [Required(ErrorMessage = "Заполните пароль подтверждения")]
        [Compare("Password", ErrorMessage = "Пароль подтверждения не совпадает")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Адрес электронной почты")]
        [Required(ErrorMessage = "Заполните почту пользователя")]
        [EmailAddress(ErrorMessage = "Некорректное имя пользователя")]
        public string Email { get; set; }
    }
}
