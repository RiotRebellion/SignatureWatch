using System.ComponentModel.DataAnnotations;

namespace SignatureWatch.UseCases.Contracts.DTO
{
    public class LoginDTO
    {
        [Display(Name = "Имя пользователя")]
        [Required(ErrorMessage = "Заполните имя пользователя")]
        [RegularExpression(@"^\p{L}$", ErrorMessage = "Неподходящие символы")]
        public string Username { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Заполните пароль")]
        public string Password { get; set; }
    }
}
