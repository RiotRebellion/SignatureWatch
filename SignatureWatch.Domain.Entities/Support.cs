using SignatureWatch.Domain.Entities.Base;

namespace SignatureWatch.Domain.Entities
{
    public class Support : Entity
    {
        public string ActivationCode { get; set; }

        public string Name { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public ICollection<SoftwareLicense> SoftwareLicenses { get; set; }
    }
}
