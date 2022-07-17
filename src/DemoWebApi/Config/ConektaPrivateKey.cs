namespace DemoWebApi.Config;

public class ConektaPrivateKey
{
    public ConektaPrivateKey(string value)
    {
        Value = value;
    }

    public string Value { get; protected set; }
}
