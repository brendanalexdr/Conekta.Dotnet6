namespace Conekta.Dotnet6.Base;

public interface IConektaObject
{
    public string id { get; }
    public string type { get; }
    public string @object { get; }
    public bool livemode { get; }
    public int created_at { get; }
    public int updated_at { get; }
}
