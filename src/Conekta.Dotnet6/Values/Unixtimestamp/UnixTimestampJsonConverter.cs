using System.Text.Json;
using System.Text.Json.Serialization;

namespace Conekta.Dotnet6.Values;

public class UnixTimestampJsonConverter : JsonConverter<UnixTimestamp>
{
    public override UnixTimestamp Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {

        int timestamp = reader.GetInt32();
        var result = UnixTimestamp.Create(timestamp);
        return result;
    }

    public override void Write(Utf8JsonWriter writer, UnixTimestamp value, JsonSerializerOptions options)
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