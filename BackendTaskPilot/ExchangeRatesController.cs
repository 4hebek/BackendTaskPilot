using Microsoft.AspNetCore.Mvc;

namespace BackendTaskPilot
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly ExchangeRateService _service;

        public ExchangeRatesController(ExchangeRateService service)
        {
            _service = service;
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var rates = _service.GetExchangeRates();
        //    return Ok(rates);
        //}
    }
}
