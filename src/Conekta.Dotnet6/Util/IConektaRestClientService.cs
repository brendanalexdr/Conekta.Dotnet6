using RestSharp;

namespace Conekta.Dotnet6.Util
{
    public interface IConektaRestClient
    {
        RestClient GetClient();
    }
}