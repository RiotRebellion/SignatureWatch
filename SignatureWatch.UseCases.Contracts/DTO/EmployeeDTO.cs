namespace SignatureWatch.UseCases.Contracts.DTO
{
    public class EmployeeDTO
    {
        public string Name { get; set; }

        public string Department { get; set; }

        public EmployeeStatusDTO EmployeeStatus { get; set; }
    }
}
