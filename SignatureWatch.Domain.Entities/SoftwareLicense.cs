using SignatureWatch.Domain.Entities.Base;

namespace SignatureWatch.Domain.Entities
{
    public class SoftwareLicense : Entity
    {
        public string LicenseNumber { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Guid? ContractGuid { get; set; }

        public Contract? Contract { get; set; }

        public Guid? SoftwareGuid { get; set; }

        public Software? Software { get; set; }

        public Guid? SupportGuid { get; set; }

        public Support? Support { get; set; }

    }
}
