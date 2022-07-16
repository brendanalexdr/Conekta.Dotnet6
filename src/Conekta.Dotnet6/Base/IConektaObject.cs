using Conekta.Dotnet6.Values;

namespace Conekta.Dotnet6.Base;

public interface IConektaObject
{
    public string id { get; }
    public string type { get; }
    public string @object { get; }
    public bool livemode { get; }
    public UnixTimestamp created_at { get; }
    public UnixTimestamp updated_at { get; }
}
