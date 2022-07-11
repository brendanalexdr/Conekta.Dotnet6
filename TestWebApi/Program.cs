using TestWebApi;

var builder = WebApplication.CreateBuilder(args);

bool isDevelopment = builder.Environment.IsDevelopment();
IConfiguration appConfig = builder.Configuration;


builder.Services.AddControllers();
builder.Services.AddConektaAssets(isDevelopment, appConfig);

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
