namespace SignatureWatch.UseCases.Contracts.ViewModels
{
    public class SignatureViewModel
    {
        public string SerialNumber { get; set; }

        public DateTime PublicKeyStartDate { get; set; }

        public DateTime PublicKeyEndDate { get; set; }

        public DateTime PrivateKeyStartDate { get; set; }

        public DateTime PrivateKeyEndDate { get; set; }

        public string SignatureType { get; set; }

        public string OwnerFullName { get; set; }
    }
}
