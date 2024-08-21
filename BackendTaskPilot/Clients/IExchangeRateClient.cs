using BackendTaskPilot.Models;

namespace BackendTaskPilot.Clients;

public interface IExchangeRateClient
{
    Task<ExchangeRatesResponse> GetExchangeRates();
}
