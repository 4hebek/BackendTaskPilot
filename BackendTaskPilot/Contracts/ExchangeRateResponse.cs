using System.Text.Json.Serialization;

namespace BackendTaskPilot.Contracts
{
    public class ExchangeRateResponse
    {
        [JsonPropertyName("rates")] 
        public List<ExchangeRate> ExchangeRates { get; set; }
    }
}
