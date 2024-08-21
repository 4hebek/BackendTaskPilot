using BackendTaskPilot.Clients;
using BackendTaskPilot.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddHttpClient<IExchangeRateClient, ExchangeRateClient>(client =>
{
    client.BaseAddress = new Uri("https://api.cnb.cz");
});

builder.Services.AddHttpClient<IExchangeRateClient, ExchangeRateClient>();
builder.Services.AddSingleton<IExchangeRateService, ExchangeRateService>();

var app = builder.Build();

// REST API to get exchange rates based on input currencies
app.MapGet("/exchangerates/targetCurrencies", async (IExchangeRateService exchangeRateService, List<string> targetCurrencies) =>
{
    var rates = await exchangeRateService.GetExchangeRates("CZK", targetCurrencies);

    if (rates == null || !rates.Any())
    {
        return Results.NotFound();
    }

    return Results.Ok(rates);
});

app.Run();

