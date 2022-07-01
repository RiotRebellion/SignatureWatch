using SignatureWatch.UseCases.Contracts.Enums;

namespace SignatureWatch.UseCases.Contracts.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Post { get; set; }

        public string Department { get; set; }

        public EmployeeStatusContract EmployeeStatus { get; set; }
    }
}
