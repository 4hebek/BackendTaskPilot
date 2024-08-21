using BackendTaskPilot.Models;
using System.Text.Json;

namespace BackendTaskPilot.Clients;

public class ExchangeRateClient : IExchangeRateClient
{
    private readonly HttpClient _httpClient;

    public ExchangeRateClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ExchangeRatesResponse> GetExchangeRates()
    {
        var response = await _httpClient.GetStringAsync("/cnbapi/exrates/daily");
        return JsonSerializer.Deserialize<ExchangeRatesResponse>(response);
    }
}