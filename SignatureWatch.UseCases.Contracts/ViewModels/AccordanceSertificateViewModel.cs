namespace SignatureWatch.UseCases.Contracts.ViewModels
{
    public class AccordanceSertificateViewModel
    {
        public Guid Guid { get; set; }

        public string RegNumber { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime? ProlongDate { get; set; }

        public string FormularName { get; set; }

        public string FormularSerialKey { get; set; }
    }
}
