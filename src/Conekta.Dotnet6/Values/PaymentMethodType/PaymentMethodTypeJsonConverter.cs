using System.Text.Json;
using System.Text.Json.Serialization;

namespace Conekta.Dotnet6.Values;

public class PaymentMethodTypeJsonConverter : JsonConverter<PaymentMethodType>
{
    public override PaymentMethodType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {

        string type = reader.GetString();
        return PaymentMethodType.Create(type); ;
    }

    public override void Write(Utf8JsonWriter writer, PaymentMethodType value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
        } 
        else if (value.IsEmpty)
        {

            writer.WriteNullValue();

        }  
        else
        {
            writer.WriteStringValue(value.Value);
        }

    }
}