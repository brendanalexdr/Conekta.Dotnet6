using Conekta.Dotnet6;
using DemoWebApi.Config;
using System.Text.Json;
using TestWebApi;

var builder = WebApplication.CreateBuilder(args);

bool isDevelopment = builder.Environment.IsDevelopment();
IConfiguration appConfig = builder.Configuration;


// conekta private keys, for prod and dev, stored in appsettings.json
var conektaPrivateKeyValue = appConfig["ConektaKeys:Prod"];
if (isDevelopment)
{
    conektaPrivateKeyValue = appConfig["ConektaKeys:Dev"];
}
var privateKey = new ConektaPrivateKey(conektaPrivateKeyValue);

builder.Services.AddSingleton<ConektaPrivateKey>(privateKey);
builder.Services.AddSingleton<IConektaRestClient>(new ConektaRestClient());

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.AllowTrailingCommas = true;

    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (isDevelopment)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
