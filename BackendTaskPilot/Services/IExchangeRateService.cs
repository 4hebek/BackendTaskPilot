using BackendTaskPilot.Contracts;

namespace BackendTaskPilot.Services
{
    public interface IExchangeRateService
    {
        Task<IEnumerable<ExchangeRate>> GetExchangeRates(string sourceCurrency, List<string> targetCurrencies);
    }
}
