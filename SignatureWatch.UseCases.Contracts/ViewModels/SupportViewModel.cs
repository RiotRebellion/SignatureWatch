namespace SignatureWatch.UseCases.Contracts.ViewModels
{
    public class SupportViewModel
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string ActivationCode { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
    }
}
