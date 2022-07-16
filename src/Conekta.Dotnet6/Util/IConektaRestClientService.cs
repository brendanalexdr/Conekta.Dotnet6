using RestSharp;

namespace Conekta.Dotnet6
{
    public interface IConektaRestClient
    {
        RestClient GetClient();
    }
}