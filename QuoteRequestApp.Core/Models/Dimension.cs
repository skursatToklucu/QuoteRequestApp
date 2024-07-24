using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRequestApp.Core.Models
{
    public class Dimension : BaseEntity
    {
        public string Type { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
    }
}
