using System.ComponentModel.DataAnnotations;

namespace SignatureWatch.Domain.Entities.Base
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
