﻿namespace SignatureWatch.UseCases.Contracts.DTO
{
    public class RegistrationDTO
    {       
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
    }
}
