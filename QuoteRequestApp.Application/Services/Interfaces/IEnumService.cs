using QuoteRequestApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRequestApp.Application.Services.Interfaces
{
    public interface IEnumService
    {
        List<string> GetCountries();
        List<string> GetCitiesByCountry(Country country);
    }
}
