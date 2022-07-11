using Conekta.Dotnet6.Models;
using Conekta.Dotnet6.Util;
using CSharpFunctionalExtensions;
using RestSharp;
using System.Text;
using System.Text.Json;

namespace Conekta.Dotnet6;

public class ConektaApi
{
    private IConektaRestClientService _client;
    private string version;
    private string locale;
    private string apiKey;


    public ConektaApi(string locale, string apiKey, IConektaRestClientService conektaRestClient)
    {
        this.apiKey = apiKey;
        this.version = "2.0.0";
        this.locale = locale;
        _client = conektaRestClient;

    }

    // ORDERS
    public async Task<Result<Conekta.Dotnet6.Models.Order, ConektaException>> GetOrderAsync(string conektaOrderId)
    {

        var request = this.GetRestRequest(Method.Get, "orders/" + conektaOrderId);

        var response = await this.GetClient().ExecuteAsync(request);

        var jsonDoc = JsonDocument.Parse(response.Content);
        var type = jsonDoc.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {

            var ex = await GetConektaExceptionAsync(response.Content);
            return Result.Failure<Conekta.Dotnet6.Models.Order, ConektaException>(ex);
        }
        var orderResponse = await ConektaSerializer.DeserializeAsync<Conekta.Dotnet6.Response.Order>(response.Content);
        var order = orderResponse.GetOrder();
        return Result.Success<Conekta.Dotnet6.Models.Order, ConektaException>(order);

    }
    public async Task<Result<Conekta.Dotnet6.Models.Order, ConektaException>> CreateOrderAsync(Conekta.Dotnet6.Models.Order order)
    {
         var request = this.GetRestRequest(Method.Post, "orders");
        request.AddJsonBody(order);

        var response = await this.GetClient().ExecuteAsync(request);

        var jsonDoc =  JsonDocument.Parse(response.Content);
        var type = jsonDoc.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {
            var ex =  await GetConektaExceptionAsync(response.Content);
            return Result.Failure<Conekta.Dotnet6.Models.Order, ConektaException>(ex);

        }

        var order_ = await ConektaSerializer.DeserializeAsync<Conekta.Dotnet6.Response.Order>(response.Content);
        Conekta.Dotnet6.Models.Order orderResponse = order_.GetOrder();
        return Result.Success<Conekta.Dotnet6.Models.Order, ConektaException>(orderResponse);

    }

    // CUSTOMERS
    public async Task<Result<Conekta.Dotnet6.Models.Customer, ConektaException>> GetCustomerAsync(string conektaCustomerId)
    {
        var request = this.GetRestRequest(Method.Get, "customers/" + conektaCustomerId);

        var response = await this.GetClient().ExecuteAsync(request);

        var jsonDoc = JsonDocument.Parse(response.Content);
        var type = jsonDoc.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {

            var ex = await GetConektaExceptionAsync(response.Content);
            return Result.Failure<Conekta.Dotnet6.Models.Customer, ConektaException>(ex);
        }
        var custResponse = await ConektaSerializer.DeserializeAsync<Conekta.Dotnet6.Response.Customer>(response.Content);
        var cust = custResponse.GetCustomer();
        return Result.Success<Conekta.Dotnet6.Models.Customer, ConektaException>(cust);

    }
    public async Task<Result<List<Conekta.Dotnet6.Models.Customer>, ConektaException>> GetCustomersAsync()
    {

        var request = this.GetRestRequest(Method.Get, "customers");
        var response = await this.GetClient().ExecuteAsync(request);
        var jsonDoc = JsonDocument.Parse(response.Content);
        var type = jsonDoc.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {

            var ex = await GetConektaExceptionAsync(response.Content);
            return Result.Failure<List<Conekta.Dotnet6.Models.Customer>, ConektaException>(new Models.ConektaException("failed"));
        }

        // assumes type is "list"

        int count = jsonDoc.RootElement.GetProperty("total").GetInt32();
        List<Conekta.Dotnet6.Models.Customer> customers = new();

        if (count > 0)
        {
            try
            {
                var json = jsonDoc.RootElement.GetProperty("data").ToString();
                var custListResponse = await ConektaSerializer.DeserializeAsync<List<Conekta.Dotnet6.Response.Customer>>(json);

                foreach (var custResponse in custListResponse)
                {
                    customers.Add(custResponse.GetCustomer());
                }

            }
            catch (Exception ex)
            {
                return Result.Failure<List<Conekta.Dotnet6.Models.Customer>, ConektaException>(new Models.ConektaException(ex.Message));
            }


        }
        return Result.Success<List<Conekta.Dotnet6.Models.Customer>, ConektaException>(customers);

    }
    public async Task<Result<bool, ConektaException>> DeleteCustomerAsync(string conektaCustomerId)
    {

        var request = this.GetRestRequest(Method.Delete, $"customers/{conektaCustomerId}");
        var response = await this.GetClient().ExecuteAsync(request);
        var obj = JsonDocument.Parse(response.Content);
        var type = obj.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {
            var ex = await GetConektaExceptionAsync(response.Content);
            return Result.Failure<bool, ConektaException>(ex);
        }

        return Result.Success<bool, ConektaException>(true);
    }
    public async Task<Result<Conekta.Dotnet6.Models.Customer, ConektaException>> CreateCustomerAsync(Conekta.Dotnet6.Models.Customer newCust)
    {

        var request = this.GetRestRequest(Method.Post, "customers");
        request.AddJsonBody(newCust);
        var response = await this.GetClient().ExecuteAsync(request);
        var obj = JsonDocument.Parse(response.Content);
        var type = obj.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {

            var ex = await GetConektaExceptionAsync(response.Content);
            return Result.Failure<Conekta.Dotnet6.Models.Customer, ConektaException>(ex);
        }
        var cust_ = await ConektaSerializer.DeserializeAsync<Conekta.Dotnet6.Response.Customer>(response.Content);
        var cust = cust_.GetCustomer();
        return Result.Success<Conekta.Dotnet6.Models.Customer, ConektaException>(cust);


    }

    // PAYMENT SOURCES
    public async Task<Result<Models.PaymentSource, ConektaException>> CreatePaymentSourceAsync(Conekta.Dotnet6.Models.PaymentSource paySource, string custId)
    {
        var request = this.GetRestRequest(Method.Post, $"customers/{custId}/payment_sources");
        request.AddJsonBody(paySource);
        var response = await this.GetClient().ExecuteAsync(request);
        var jsonDoc =  JsonDocument.Parse(response.Content);
        var type = jsonDoc.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {
            var ex = await GetConektaExceptionAsync(response.Content);
            return Result.Failure<Models.PaymentSource, ConektaException>(ex);

        }
        Models.PaymentSource paymentSource;
        try
        {
            paymentSource = await ConektaSerializer.DeserializeAsync<Models.PaymentSource>(response.Content);
        } catch(Exception ex)
        {

            return Result.Failure<Models.PaymentSource, ConektaException>(new Models.ConektaException(ex.Message));
        }
         
        return Result.Success<Models.PaymentSource, ConektaException>(paymentSource);
    }


    // PAYMENT LINK
    public async Task<Result<Response.PaymentLink, ConektaException>> CreatePaymentLinkAsync(Models.PaymentLink paymentLink)
    {

        var request = this.GetRestRequest(Method.Post, "checkouts");
        request.AddBody(paymentLink);
        var response = await this.GetClient().ExecuteAsync(request);
        var jsonDoc = JsonDocument.Parse(response.Content);
        var type = jsonDoc.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {
            var ex = await GetConektaExceptionAsync(response.Content);
            return Result.Failure<Response.PaymentLink, ConektaException>(ex);
        }
        var paymentLinkResponse = await ConektaSerializer.DeserializeAsync<Response.PaymentLink>(response.Content);
        return Result.Success<Response.PaymentLink, ConektaException>(paymentLinkResponse);

    }


    private RestRequest GetRestRequest(RestSharp.Method method, string url)
    {
        var request = new RestRequest(url, method);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Accept", "application/vnd.conekta-v" + version + "+json");
        request.AddHeader("Authorization", "Basic " + GetBase64String(apiKey) + ":");
        request.AddHeader("Accept-Language", locale);
     
        return request;

    }
    private string GetBase64String(string text)
    {
        byte[] textAsBytes = Encoding.UTF8.GetBytes(text);
        return Convert.ToBase64String(textAsBytes);
    }

    private async Task<ConektaException> GetConektaExceptionAsync(string json)
    {
        var ex_ =  await ConektaSerializer.DeserializeAsync<ConektaException>(json);
        ConektaException ex = new Models.ConektaException(ex_.details[0].debug_message);
        ex.SetDetails(ex_.details);
        return ex;
    }

    private RestClient GetClient()
    {
        return _client.GetClient();
    }
}
