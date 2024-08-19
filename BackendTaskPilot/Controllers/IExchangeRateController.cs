using Microsoft.AspNetCore.Mvc;

namespace BackendTaskPilot.Controllers
{
    public interface IExchangeRateController
    {
        [HttpGet("{route}")]
        Task<IActionResult> Get(List<string> currencies);
    }
}
