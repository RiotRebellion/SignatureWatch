using SignatureWatch.Domain.Entities.Base;

namespace SignatureWatch.Domain.Entities
{
    public class Employee : Entity
    {
        public string Name { get; set; }

        public string Department { get; set; }

        public EmployeeStatus EmployeeStatus { get; set; }
    }
}
