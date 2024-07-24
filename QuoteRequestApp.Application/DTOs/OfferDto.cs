using QuoteRequestApp.Core.Enums;
using QuoteRequestApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRequestApp.Application.DTOs
{
    public class OfferDto
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
    }
}
