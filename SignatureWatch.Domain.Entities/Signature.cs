using SignatureWatch.Domain.Entities.Base;

namespace SignatureWatch.Domain.Entities
{
    public class Signature : Entity
    {        
        public string SerialNumber { get; set; }

        public DateTime PublicKeyStartDate { get; set; }

        public DateTime PublicKeyEndDate { get; set; }

        public DateTime PrivateKeyStartDate { get; set; }

        public DateTime PrivateKeyEndDate { get; set; }

        public SignatureType SignatureType { get; set; }

        public Employee Owner { get; set; }
    }
}
