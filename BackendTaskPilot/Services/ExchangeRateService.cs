using BackendTaskPilot.Clients;
using BackendTaskPilot.Models;

namespace BackendTaskPilot.Services;

public class ExchangeRateService : IExchangeRateService
{
    private readonly IExchangeRateClient _client;

    public ExchangeRateService(IExchangeRateClient client)
    {
        _client = client;
    }

    public async Task<List<ExchangeRate>> GetExchangeRates(string sourceCurrency, IEnumerable<string> targetCurrencies)
    {
        var response = await _client.GetExchangeRates();
        return response.Rates
            .Where(rate => targetCurrencies.Contains(rate.CurrencyCode))
            .ToList();
    }
}
