using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConektaDotnet6.Values;

public class ConektaDatetimeJsonConverter : JsonConverter<ConektaDatetime>
{
    public override ConektaDatetime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {

        int timestamp = reader.GetInt32();
        var result = ConektaDatetime.Create(timestamp);
        return result;
    }

    public override void Write(Utf8JsonWriter writer, ConektaDatetime value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNumberValue(0);
        }
        else
        {
            writer.WriteNumberValue(value.Value);
        }


    }
}