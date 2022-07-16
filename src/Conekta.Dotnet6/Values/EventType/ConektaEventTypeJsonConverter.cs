using System.Text.Json;
using System.Text.Json.Serialization;

namespace Conekta.Dotnet6.Values;

public class ConektaEventTypeJsonConverter : JsonConverter<ConektaEventType>
{
    public override ConektaEventType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string type = reader.GetString();
        return ConektaEventType.Create(type); ;
    }

    public override void Write(Utf8JsonWriter writer, ConektaEventType value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
        } else if (value.Value == "-")
        {
            writer.WriteNullValue();

        } else
        {
            writer.WriteStringValue(value.Value);
        }

    }
}
