using SignatureWatch.UseCases.Contracts.Enums;

namespace SignatureWatch.UseCases.Contracts.DTO
{
    public class EmployeeDTO
    {
        public string Name { get; set; }

        public string Department { get; set; }

        public string Post { get; set; }

        public EmployeeStatusContract EmployeeStatus { get; set; }
    }
}
