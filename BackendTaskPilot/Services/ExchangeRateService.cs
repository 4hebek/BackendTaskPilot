using BackendTaskPilot.Clients;
using BackendTaskPilot.Contracts;

namespace BackendTaskPilot.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IExchangeRateClient _client;

        public ExchangeRateService(IExchangeRateClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ExchangeRate>> GetExchangeRates(string sourceCurrency, List<string> targetCurrencies)
        {
            // correlationToken
            var exchangeRatesResponse = await _client.GetExchangeRates();

            var matchingRates = exchangeRatesResponse.ExchangeRates
            .Where(rate => targetCurrencies.Contains(rate.CurrencyCode))
            .ToList();

            // Additional logic can be added here if the source currency needs to be different from CZK
            // For now, we assume the source is always CZK, so no conversion is needed

            return matchingRates;
        }
    }
}
