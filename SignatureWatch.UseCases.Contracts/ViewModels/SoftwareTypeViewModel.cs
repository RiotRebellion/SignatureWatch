using SignatureWatch.UseCases.Contracts.Enums;

namespace SignatureWatch.UseCases.Contracts.ViewModels
{
    public class SoftwareTypeViewModel
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public SoftwareLocationContract SoftwareLocation { get; set; }
    }
}
