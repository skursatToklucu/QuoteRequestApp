using Microsoft.AspNetCore.Mvc;
using QuoteRequestApp.Application.DTOs;
using QuoteRequestApp.Application.Services.Interfaces;
using QuoteRequestApp.Core.Enums;
using QuoteRequestApp.Core.Models;
using System.Security.Claims;

namespace QuoteRequestApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet("city/{city}")]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffersByCity(string city)
        {
            var offers = await _offerService.GetOffersByCityAsync(city);
            return Ok(offers);
        }

        [HttpGet("country/{country}")]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffersByCountry(string country)
        {
            var offers = await _offerService.GetOffersByCountryAsync(country);
            return Ok(offers);
        }


        [HttpPost("createOffer")]
        public async Task<IActionResult> CreateOffer([FromBody] OfferDto offerDto)
        {
            if (offerDto == null)
                return BadRequest("Offer data is null.");

            var offer = new Offer
            {
                UserId = offerDto.UserId,
                Mode = offerDto.Mode,
                MovementType = offerDto.MovementType,
                Incoterms = offerDto.Incoterms,
                Country = offerDto.Country,
                City = offerDto.City,
                PackageType = offerDto.PackageType,
                Unit1 = offerDto.Unit1,
                Unit2 = offerDto.Unit2,
                Currency = offerDto.Currency
            };

            await _offerService.CreateOfferAsync(offer);
            return Ok(offer);
        }

        [HttpGet("offers/{userId}")]
        public async Task<ActionResult<IEnumerable<Offer>>> GetUserOffers(Guid userId)
        {
            var offers = await _offerService.GetOffersByUserIdAsync(userId);
            if (offers == null || !offers.Any())
            {
                return NotFound("No offers found for this user.");
            }
            return Ok(offers);
        }

    }
}

