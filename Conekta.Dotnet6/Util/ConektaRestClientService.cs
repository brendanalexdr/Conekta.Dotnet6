using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;

namespace Conekta.Dotnet6.Util;

// It is recommended that the RestClient be used as a Singleton  
// https://restsharp.dev/usage.html#api-client

public class ConektaRestClientService : IConektaRestClientService
{
    private string baseUri = "https://api.conekta.io";
    private RestClient _client;

    public ConektaRestClientService()
    {

        var client = new RestClient(baseUri);
        client.UseSystemTextJson(new JsonSerializerOptions
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            AllowTrailingCommas = true
        });
        _client = client;  
    }
    public RestClient GetClient()
    {
        return _client;
    }
}
