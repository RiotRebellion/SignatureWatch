using SignatureWatch.UseCases.Contracts.Enums;

namespace SignatureWatch.UseCases.Contracts.ViewModels
{
    public class SoftwareViewModel
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public string SoftwareTypeName { get; set; }

        public SoftwareLocationContract SoftwareLocation { get; set; }

        public string DistributionNumber { get; set; }

    }
}
