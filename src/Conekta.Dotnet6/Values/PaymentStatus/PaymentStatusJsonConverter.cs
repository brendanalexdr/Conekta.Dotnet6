using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConektaDotnet6.Values;

public class PaymentStatusJsonConverter : JsonConverter<PaymentStatus>
{
    public override PaymentStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string value = reader.GetString();

        return PaymentStatus.Create(value);
    }

    public override void Write(Utf8JsonWriter writer, PaymentStatus value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
        } else if (value.IsEmpty)
        {

            writer.WriteNullValue();
        } else
        {

            writer.WriteStringValue(value.Value);

        };
    }
}
