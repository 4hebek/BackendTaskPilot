using BackendTaskPilot.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendTaskPilot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeRateController : ControllerBase
    {
        private readonly IExchangeRateService _service;

        public ExchangeRateController(IExchangeRateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetExchangeRates([FromQuery] string sourceCurrency = "CZK", [FromQuery] List<string> targetCurrencies = null)
        {
            if (targetCurrencies == null || !targetCurrencies.Any())
            {
                return BadRequest("No currencies specified.");
            }

            var rates = await _service.GetExchangeRates(sourceCurrency, targetCurrencies);
            return Ok(rates);
        }
    }
}
