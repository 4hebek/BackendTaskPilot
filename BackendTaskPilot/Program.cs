using BackendTaskPilot.Clients;
using BackendTaskPilot.Services;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//builder.Services.AddSingleton<ExchangeRateService>();

//var app = builder.Build();

//ExchangeRateService service = new ExchangeRateService();

//// REST API to get exchange rates based on input currencies
//app.MapGet("/", service.GetExchangeRates);

//Console.WriteLine(new ExchangeRateService().GetExchangeRates(new List<string> { "USD", "EUR", "JPY", "SAR", "KES" }));
//app.Run();



var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddHttpClient<IExchangeRateClient, ExchangeRateClient>();
builder.Services.AddSingleton<IExchangeRateService, ExchangeRateService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Resolve the service from the DI container
var exchangeRateService = app.Services.GetRequiredService<IExchangeRateService>();

var rates = exchangeRateService.GetExchangeRates("CZK", new List<string> { "USD", "EUR", "JPY", "SAR", "KES" }).Result;
Console.WriteLine(rates);

app.Run();
