using CSharpFunctionalExtensions;
using System.Text.Json.Serialization;

namespace ConektaDotnet6.Values;

[JsonConverter(typeof(ConektaDatetimeJsonConverter))]
public class ConektaDatetime : ValueObject<ConektaDatetime>
{
    public static ConektaDatetime Empty = new ConektaDatetime(0);

    public bool IsEmpty
    {

        get
        {
            return Value == 0;
        }
    }

    public int Value { get; protected set; }


    protected ConektaDatetime()
    {

    }

    protected ConektaDatetime(int value )
    {
        Value = value;
    }

    public static ConektaDatetime Create(DateTime value)
    {
        int unixTimestamp = (int)value.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        
        return new ConektaDatetime(unixTimestamp);

    }

    public static ConektaDatetime Create(int value)
    {

        return new ConektaDatetime(value);

    }

    public DateTime ToDateTime()
    {
        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(Value).ToLocalTime();
        return dtDateTime;


    }

    protected override bool EqualsCore(ConektaDatetime other)
    {
        return Value == other.Value;
    }

    protected override int GetHashCodeCore()
    {
        return Value.GetHashCode();
    }
}
