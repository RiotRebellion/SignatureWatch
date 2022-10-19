namespace SignatureWatch.UseCases.Contracts.DTO
{
    public class SupportDTO
    {
        public string ActivationCode { get; set; }

        public string Name { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
    }
}
