using BackendTaskPilot.Models;

namespace BackendTaskPilot.Services;

public interface IExchangeRateService
{
    Task<List<ExchangeRate>> GetExchangeRates(string sourceCurrency, IEnumerable<string> targetCurrencies);
}
