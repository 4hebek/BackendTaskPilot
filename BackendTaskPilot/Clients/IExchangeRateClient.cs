using BackendTaskPilot.Contracts;

namespace BackendTaskPilot.Clients
{
    public interface IExchangeRateClient
    {
        Task<ExchangeRateResponse> GetExchangeRates();
    }
}
