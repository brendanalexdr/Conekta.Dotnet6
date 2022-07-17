using RestSharp;

namespace ConektaDotnet6
{
    public interface IConektaRestClient
    {
        RestClient GetClient();
    }
}