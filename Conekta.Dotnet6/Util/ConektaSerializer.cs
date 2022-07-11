using System.Text.Json;

namespace Conekta.Dotnet6.Util;

public static class ConektaSerializer
{

    public static async Task<T> DeserializeAsync<T>(string json)
    {
        // convert string to stream
        byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(json);
        MemoryStream stream = new MemoryStream(byteArray);

        T obj = await JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions
        {

            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        });

        return obj;
    }

    public static JsonDocument ToJsonDocument(string json)
    {
        return JsonDocument.Parse(json, new JsonDocumentOptions
        {
            AllowTrailingCommas = true
        });

    }

}
