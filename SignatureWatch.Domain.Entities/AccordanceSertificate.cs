using SignatureWatch.Domain.Entities.Base;

namespace SignatureWatch.Domain.Entities
{
    public class AccordanceSertificate : Entity
    {
        public string RegNumber { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime? ProlongDate { get; set; }

        public Guid FormularGuid { get; set; }

        public Formular Formular { get; set; }
    }
}
