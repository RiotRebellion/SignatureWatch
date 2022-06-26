namespace SignatureWatch.UseCases.Contracts.ViewModels
{
    public class SignatureViewModel
    {
        public string SerialNumber { get; set; }

        public DateOnly PublicKeyStartDate { get; set; }

        public DateOnly PublicKeyEndDate { get; set; }

        public DateOnly PrivateKeyStartDate { get; set; }

        public DateOnly PrivateKeyEndDate { get; set; }

        public SignatureTypeViewModel SignatureType { get; set; }

        public EmployeeViewModel Owner { get; set; }
    }
}
