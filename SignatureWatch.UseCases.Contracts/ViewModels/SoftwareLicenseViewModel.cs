namespace SignatureWatch.UseCases.Contracts.ViewModels
{
    public class SoftwareLicenseViewModel
    {
        public Guid Guid { get; set; }

        public string LicenseNumber { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string ContractNumber { get; set; }

        public string SoftwareName { get; set; }

        public string SoftwareVersion { get; set; }

        public string SupportName { get; set; }
    }
}
