using System.Text.Json.Serialization;

namespace BackendTaskPilot.Models;

public class ExchangeRate
{
    [JsonPropertyName("currencyCode")]
    public string CurrencyCode { get; set; }

    [JsonPropertyName("rate")]
    public decimal RateValue { get; set; }
}
