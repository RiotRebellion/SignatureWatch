using SignatureWatch.UseCases.Contracts.Enums;

namespace SignatureWatch.UseCases.Contracts.DTO
{
    public class SoftwareTypeDTO
    {
        public string Name { get; set; }

        public SoftwareLocationContract SoftwareLocation { get; set; }
    }
}
