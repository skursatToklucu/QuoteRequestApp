using QuoteRequestApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRequestApp.Core.Models
{
    public class Offer : BaseEntity
    {
        public string Mode { get; set; }
        public string MovementType { get; set; }
        public string Incoterms { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PackageType { get; set; }
        public string Unit1 { get; set; }
        public string Unit2 { get; set; }
        public string Currency { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
