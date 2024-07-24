using Microsoft.EntityFrameworkCore;
using QuoteRequestApp.Core.Enums;
using QuoteRequestApp.Core.Models;
using QuoteRequestApp.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRequestApp.DataAccess.Repositories
{
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {
        public OfferRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Offer>> GetOffersByCityAsync(string city)
        {
            return await _context.Offers.Where(o => o.City == city).ToListAsync();
        }

        public async Task<IEnumerable<Offer>> GetOffersByCountryAsync(string country)
        {
            return await _context.Offers.Where(o => o.Country == country).ToListAsync();
        }

    }
}
