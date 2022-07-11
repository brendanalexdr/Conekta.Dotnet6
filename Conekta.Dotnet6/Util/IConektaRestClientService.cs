using RestSharp;

namespace Conekta.Dotnet6.Util
{
    public interface IConektaRestClientService
    {
        RestClient GetClient();
    }
}