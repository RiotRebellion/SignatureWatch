using SignatureWatch.Domain.Entities.Base;

namespace SignatureWatch.Domain.Entities
{
    public class Contract : Entity
    {
        public string ContractNumber { get; set; }

        public DateTime Date { get; set; }
    }
}
