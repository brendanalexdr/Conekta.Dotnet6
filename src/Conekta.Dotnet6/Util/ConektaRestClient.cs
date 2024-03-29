﻿using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;

namespace ConektaDotnet6;

// It is recommended that the RestClient be used as a Singleton  
// https://restsharp.dev/usage.html#api-client

public class ConektaRestClient : IConektaRestClient
{
    private string _baseUrl = "https://api.conekta.io";
    private RestClient _client;

    public ConektaRestClient(int maxTimeout = 300000)
    {

        var client = new RestClient(new RestClientOptions(_baseUrl) { 
        
            MaxTimeout = maxTimeout

        });
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
