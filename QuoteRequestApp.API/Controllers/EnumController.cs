using Microsoft.AspNetCore.Mvc;
using QuoteRequestApp.Application.Services.Interfaces;
using QuoteRequestApp.Core.Enums;

namespace QuoteRequestApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        private readonly IEnumService _enumService;

        public EnumController(IEnumService enumService)
        {
            _enumService = enumService;
        }

        [HttpGet("modes")]
        public IActionResult GetModes()
        {
            var modes = Enum.GetValues(typeof(TransportMode)).Cast<TransportMode>()
                .Select(e => e.ToString()).ToList();
            return Ok(modes);
        }

        [HttpGet("movementTypes")]
        public IActionResult GetMovementTypes()
        {
            var movementTypes = Enum.GetValues(typeof(MovementType)).Cast<MovementType>()
                .Select(e => e.ToString()).ToList();
            return Ok(movementTypes);
        }

        [HttpGet("incoterms")]
        public IActionResult GetIncoterms()
        {
            var incoterms = Enum.GetValues(typeof(Incoterms)).Cast<Incoterms>()
                .Select(e => e.ToString()).ToList();
            return Ok(incoterms);
        }

        [HttpGet("countries")]
        public IActionResult GetCountries()
        {
            var countries = _enumService.GetCountries();
            return Ok(countries);
        }

        [HttpGet("cities/{country}")]
        public IActionResult GetCities(Country country)
        {
            var cities = _enumService.GetCitiesByCountry(country);
            return Ok(cities);
        }

        [HttpGet("packageTypes")]
        public IActionResult GetPackageTypes()
        {
            var packageTypes = Enum.GetValues(typeof(PackageType)).Cast<PackageType>()
                .Select(e => e.ToString()).ToList();
            return Ok(packageTypes);
        }

        [HttpGet("units")]
        public IActionResult GetUnits()
        {
            var units = Enum.GetValues(typeof(Unit)).Cast<Unit>()
                .Select(e => e.ToString()).ToList();
            return Ok(units);
        }

        [HttpGet("currencies")]
        public IActionResult GetCurrencies()
        {
            var currencies = Enum.GetValues(typeof(Currency)).Cast<Currency>()
                .Select(e => e.ToString()).ToList();
            return Ok(currencies);
        }
    }
}
