using CSharpFunctionalExtensions;
using System.Text.Json.Serialization;

namespace Conekta.Dotnet6.Values;

[JsonConverter(typeof(UnixTimestampJsonConverter))]
public class UnixTimestamp : ValueObject<UnixTimestamp>
{
    public static UnixTimestamp Empty = new UnixTimestamp(0);

    public bool IsEmpty
    {

        get
        {
            return Value == 0;
        }
    }

    public int Value { get; protected set; }


    protected UnixTimestamp()
    {

    }

    protected UnixTimestamp(int value )
    {
        Value = value;
    }

    public static UnixTimestamp Create(DateTime value)
    {
        int unixTimestamp = (int)value.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        
        return new UnixTimestamp(unixTimestamp);

    }

    public static UnixTimestamp Create(int value)
    {

        return new UnixTimestamp(value);

    }

    public DateTime ToDateTime()
    {
        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(Value).ToLocalTime();
        return dtDateTime;


    }

    protected override bool EqualsCore(UnixTimestamp other)
    {
        return Value == other.Value;
    }

    protected override int GetHashCodeCore()
    {
        return Value.GetHashCode();
    }
}
