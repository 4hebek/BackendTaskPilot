using BackendTaskPilot.Contracts;
using System.Text.Json;

namespace BackendTaskPilot.Clients
{
    public class ExchangeRateClient : IExchangeRateClient
    {
        private readonly HttpClient _httpClient;

        public ExchangeRateClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.cnb.cz/cnbapi/exrates/daily");
        }

        public async Task<ExchangeRateResponse> GetExchangeRates()
        {
            //HttpResponseMessage response = await _client.GetAsync(_url);
            //var jsonResponse = await response.Content.ReadAsStringAsync();
            //var exchangeRatesResponse = JsonSerializer.Deserialize<ExchangeRateResponse>(jsonResponse);

            var response = await _httpClient.GetStringAsync(_httpClient.BaseAddress);
            return JsonSerializer.Deserialize<ExchangeRateResponse>(response);
        }
    }
}