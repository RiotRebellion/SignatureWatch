namespace SignatureWatch.UseCases.Contracts.DTO
{
    public class SignatureDTO
    {
        public string SerialNumber { get; set; }

        public DateOnly PublicKeyStartDate { get; set; }

        public DateOnly PublicKeyEndDate { get; set; }

        public DateOnly PrivateKeyStartDate { get; set; }

        public DateOnly PrivateKeyEndDate { get; set; }

        public SignatureTypeDTO SignatureType { get; set; }

        public EmployeeDTO Owner { get; set; }
    }
}
