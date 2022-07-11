using Conekta.Dotnet6.Util;

namespace TestWebApi;

public static class ConektaConfig
{
    public static IServiceCollection AddConektaAssets(
        this IServiceCollection services, bool isDevelopment,
        IConfiguration appConfig)
    {


        var privateKey = new ConektaPrivateKey("private_key");

        services.AddSingleton(privateKey);
        services.AddSingleton<IConektaRestClientService>(new ConektaRestClientService());

        

        return services;
    }
}
