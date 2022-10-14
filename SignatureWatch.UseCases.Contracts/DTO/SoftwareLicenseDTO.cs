namespace SignatureWatch.UseCases.Contracts.DTO
{
    public class SoftwareLicenseDTO
    {
        public string LicenceNumber { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Guid ContractGuid { get; set; }

        public Guid SoftwareGuid { get; set; }

        public Guid SupportGuid { get; set; }
    }
}
