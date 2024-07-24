using Microsoft.AspNetCore.Mvc;
using QuoteRequestApp.Application.Services.Interfaces;

namespace QuoteRequestApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DimensionController : ControllerBase
    {
        private readonly IDimensionService _dimensionService;

        public DimensionController(IDimensionService dimensionService)
        {
            _dimensionService = dimensionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDimensions()
        {
            var dimensions = await _dimensionService.GetDimensionsAsync();
            return Ok(dimensions);
        }

        [HttpPost("calculatePalletCount")]
        public async Task<IActionResult> CalculatePalletCount([FromBody] CalculatePalletCountRequest request)
        {
            try
            {
                int count = await _dimensionService.CalculatePalletCount(request.UnitLength, request.UnitType);
                return Ok(count);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class CalculatePalletCountRequest
    {
        public double UnitLength { get; set; }
        public string UnitType { get; set; }
    }
}
