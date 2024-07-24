using QuoteRequestApp.Core.Enums;
using QuoteRequestApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRequestApp.DataAccess.Repositories.Interfaces
{
    public interface IOfferRepository : IRepository<Offer>
    {
        Task<IEnumerable<Offer>> GetOffersByCityAsync(string city);
        Task<IEnumerable<Offer>> GetOffersByCountryAsync(string country);
    }
}
