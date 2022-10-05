using SignatureWatch.Domain.Entities.Base;

namespace SignatureWatch.Domain.Entities
{
    public class SoftwareType : Entity
    {
        public string Name { get; set; }

        public SoftwareLocation SoftwareLocation { get; set; }
    }
}
