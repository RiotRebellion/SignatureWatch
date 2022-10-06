using SignatureWatch.Domain.Entities.Base;

namespace SignatureWatch.Domain.Entities
{
    public class Software : Entity
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public Guid SoftwareTypeGuid { get; set; }

        public SoftwareType SoftwareType { get; set; }

        public Guid? DistributionGuid { get; set; }

        public Distribution? Distribution { get; set; }

        public ICollection<SoftwareLicense> SoftwareLicenses { get; set; }
    }
}
