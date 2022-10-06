using SignatureWatch.Domain.Entities.Base;

namespace SignatureWatch.Domain.Entities
{
    public class Formular : Entity
    {
        public string Name { get; set; }

        public string SerialKey { get; set; }

        public string OrgRegNumber { get; set; }

        public string ProtectionKey { get; set; }

        public Distribution Distribution { get; set; }

        public ICollection<AccordanceSertificate> AccordanceSertificates { get; set; }


    }
}
