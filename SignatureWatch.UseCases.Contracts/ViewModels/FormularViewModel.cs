namespace SignatureWatch.UseCases.Contracts.ViewModels
{
    public class FormularViewModel
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string SerialKey { get; set; }

        public string OrgRegNumber { get; set; }

        public string ProtectionKey { get; set; }

        public string DistributionNumber { get; set; }
    }
}
