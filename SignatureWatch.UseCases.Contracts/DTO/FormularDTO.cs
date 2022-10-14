namespace SignatureWatch.UseCases.Contracts.DTO
{
    public class FormularDTO
    {
        public string Name { get; set; }

        public string SerialKey { get; set; }

        public string OrgRegNumber { get; set; }

        public string ProtectionKey { get; set; }

        public Guid DistributionGuid { get; set; }

    }
}
