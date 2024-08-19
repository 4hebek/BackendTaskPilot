using BackendTaskPilot.Contracts;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BackendTaskPilot
{
    public class ExchangeRateService
    {
        private readonly HttpClient _client;
        private readonly string _url = "https://api.cnb.cz/cnbapi/exrates/daily";

        public ExchangeRateService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(_url)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<ExchangeRate>> GetExchangeRates(List<string> currencies)
        {
            var data = await _client.GetStringAsync(_url);
            HttpResponseMessage response = await _client.GetAsync(_url);

            var exchangeRates = new List<ExchangeRate>();
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var exchangeRatesResponse = JsonSerializer.Deserialize<ExchangeRateResponse>(jsonResponse);
                    exchangeRates = exchangeRatesResponse?.ExchangeRates
                        .Where(rate => currencies.Contains(rate.CurrencyCode))
                        .ToList();
                }
                else
                {
                    // get error response and log it
                }
            }
            catch (HttpRequestException ex)
            {
                // catch exception and log it
            }
            
            return exchangeRates;
        }
    }
}
