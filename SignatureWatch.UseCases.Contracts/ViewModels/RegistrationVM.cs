using System.ComponentModel.DataAnnotations;

namespace SignatureWatch.UseCases.Contracts.ViewModels
{
    public class RegistrationVM
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
