using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConektaDotnet6.Values;

public class ConektaAmountJsonConverter : JsonConverter<ConektaAmount>
{
    public override ConektaAmount Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        int conektaInt = reader.GetInt32();

        return new ConektaAmount(conektaInt);

    }

    public override void Write(Utf8JsonWriter writer, ConektaAmount value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNumberValue(0);

        } else
        {

            writer.WriteNumberValue(value.Value);

        }
    }
}
