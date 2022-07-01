using SignatureWatch.UseCases.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureWatch.UseCases.Contracts.ViewModels
{
    public class SignatureViewModel
    {
        public Guid Id { get; set; }

        public string SerialNumber { get; set; }

        public DateTime PublicKeyStartDate { get; set; }

        public DateTime PublicKeyEndDate { get; set; }

        public DateTime PrivateKeyStartDate { get; set; }

        public DateTime PrivateKeyEndDate { get; set; }

        public SignatureTypeContract SignatureType { get; set; }

        public string EmployeeName { get; set; }
    }
}
