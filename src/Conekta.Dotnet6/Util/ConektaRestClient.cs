using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;

namespace Conekta.Dotnet6;

// It is recommended that the RestClient be used as a Singleton  
// https://restsharp.dev/usage.html#api-client

public class ConektaRestClient : IConektaRestClient
{
    private string baseUri = "https://api.conekta.io";
    private RestClient _client;

    public ConektaRestClient()
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
