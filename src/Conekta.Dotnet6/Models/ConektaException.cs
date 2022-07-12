using System.Text.Json.Serialization;

namespace Conekta.Dotnet6.Models;

public class ConektaException : Exception
{

    [JsonInclude]
    public List<ConektaExceptionDetail> details { get; protected set; } = new();
    public string message;

    public ConektaException(string message) : base(message)
    {
        this.message = message;
    }

    public void SetDetails(List<ConektaExceptionDetail> _details)
    {
        details = _details;
    }
}
