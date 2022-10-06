using SignatureWatch.Domain.Entities.Base;

namespace SignatureWatch.Domain.Entities
{
    public class Distribution : Entity
    {
        public string Number { get; set; }

        public string OrgRegNumber { get; set; }

        public Guid FormularGuid { get; set; }

        public Formular? Formular { get; set; }

        public Software Software { get; set; }
    }
}
