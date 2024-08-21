using System.Text.Json.Serialization;

namespace BackendTaskPilot.Models;

public class ExchangeRatesResponse
{
    [JsonPropertyName("rates")]
    public IEnumerable<ExchangeRate> Rates { get; set; } 
}