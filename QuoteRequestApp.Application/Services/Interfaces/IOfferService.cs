using QuoteRequestApp.Core.Enums;
using QuoteRequestApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRequestApp.Application.Services.Interfaces
{
    public interface IOfferService
    {
        Task<IEnumerable<Offer>> GetOffersByCityAsync(string city);
        Task<IEnumerable<Offer>> GetOffersByCountryAsync(string country);
        Task CreateOfferAsync(Offer offer);
        Task<IEnumerable<Offer>> GetOffersByUserIdAsync(Guid userId);
    }
}
