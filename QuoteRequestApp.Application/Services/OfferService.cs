using QuoteRequestApp.Application.Services.Interfaces;
using QuoteRequestApp.Core.Enums;
using QuoteRequestApp.Core.Models;
using QuoteRequestApp.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRequestApp.Application.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IRepository<Dimension> _dimensionsRepository;

        public OfferService(IOfferRepository offerRepository, IRepository<Dimension> dimensionsRepository)
        {
            _offerRepository = offerRepository;
            _dimensionsRepository = dimensionsRepository;
        }

        public async Task<IEnumerable<Offer>> GetOffersByCityAsync(string city)
        {
            return await _offerRepository.GetOffersByCityAsync(city);
        }

        public async Task<IEnumerable<Offer>> GetOffersByCountryAsync(string country)
        {
            return await _offerRepository.GetOffersByCountryAsync(country);
        }

        public async Task CreateOfferAsync(Offer offer)
        {
            await _offerRepository.AddAsync(offer);
        }

        public async Task<IEnumerable<Offer>> GetOffersByUserIdAsync(Guid userId)
        {
            return await _offerRepository.FindAsync(o => o.UserId == userId);
        }

    }
}
