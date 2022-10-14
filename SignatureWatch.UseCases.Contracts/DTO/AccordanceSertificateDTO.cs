namespace SignatureWatch.UseCases.Contracts.DTO
{
    public class AccordanceSertificateDTO
    {
        public string RegNum { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime? ProlongDate { get; set; }

        public Guid FormularGuid { get; set; }
    }
}
