using Conekta.Dotnet6.Util;

namespace TestWebApi;

public static class ConektaConfig
{
    public static IServiceCollection AddConektaAssets(
        this IServiceCollection services, bool isDevelopment,
        IConfiguration appConfig)
    {

        var conektaPrivateKeyValue = appConfig["ConektaKeys:Prod"];
       
        if (isDevelopment)
        {
            conektaPrivateKeyValue = appConfig["ConektaKeys:Dev"];
        }
        var privateKey = new ConektaPrivateKey(conektaPrivateKeyValue);

        services.AddSingleton(privateKey);
        services.AddSingleton<IConektaRestClientService>(new ConektaRestClientService());

        return services;
    }
}
