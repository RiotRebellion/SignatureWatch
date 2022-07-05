using SignatureWatch.UseCases.Contracts.Enums;
using System.Text.Json.Serialization;

namespace SignatureWatch.UseCases.Contracts.DTO
{
    public class SignatureDTO
    {
        public string SerialNumber { get; set; }

        public DateTime PublicKeyStartDate { get; set; }

        public DateTime PublicKeyEndDate { get; set; }

        public DateTime PrivateKeyStartDate { get; set; }

        public DateTime PrivateKeyEndDate { get; set; }

        public SignatureTypeContract SignatureType { get; set; }

        public EmployeeDTO Owner { get; set; }
    }
}
