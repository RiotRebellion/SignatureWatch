namespace SignatureWatch.UseCases.Contracts.DTO
{
    public class SoftwareDTO
    {
        public string Name { get; set; }
        
        public string Version { get; set; }

        public Guid SoftwareTypeGuid { get; set; }
    }
}
