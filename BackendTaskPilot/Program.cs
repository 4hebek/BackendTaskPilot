using BackendTaskPilot;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<ExchangeRateService>();

var app = builder.Build();

ExchangeRateService service = new ExchangeRateService();

// REST API to get exchange rates based on input currencies
app.MapGet("/", service.GetExchangeRates);

Console.WriteLine(new ExchangeRateService().GetExchangeRates(new List<string> { "USD", "EUR", "JPY", "SAR", "KES" }));
app.Run();

