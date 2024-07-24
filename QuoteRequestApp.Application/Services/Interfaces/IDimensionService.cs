using QuoteRequestApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRequestApp.Application.Services.Interfaces
{
    public interface IDimensionService
    {
        Task<IEnumerable<Dimension>> GetDimensionsAsync();
        Task<int> CalculatePalletCount(double unitLength, string unitType);
    }
}
