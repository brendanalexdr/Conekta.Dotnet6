using Conekta.Dotnet6.Models;
using Conekta.Dotnet6.Util;
using CSharpFunctionalExtensions;
using RestSharp;
using System.Text;

namespace Conekta.Dotnet6;

public class ConektaApi
{
    private IConektaRestClient _client;
    private string version;
    private string locale;
    private string apiKeyBase64;


    public ConektaApi(string locale, string apiKey, IConektaRestClient conektaRestClient)
    {
        this.apiKeyBase64 = GetBase64String(apiKey);
        this.version = "2.0.0";
        this.locale = locale;
        _client = conektaRestClient;

    }

    // ORDERS
    public async Task<Result<Models.Order, ConektaException>> GetOrderAsync(string conektaOrderId)
    {

        var request = this.GetRestRequest(Method.Get, "orders/" + conektaOrderId);

        var response = await this.GetClient().ExecuteAsync(request);

        var jsonDoc = ConektaSerializer.ToJsonDocument(response.Content);
        var type = jsonDoc.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {

            var ex = await GetConektaExceptionAsync(response.Content);
            return Result.Failure<Models.Order, ConektaException>(ex);
        }
        var orderResponse = await ConektaSerializer.DeserializeAsync<Conekta.Dotnet6.Response.Order>(response.Content);
        var order = orderResponse.GetOrder();
        return Result.Success<Models.Order, ConektaException>(order);

    }
    public async Task<Result<Models.Order, ConektaException>> CreateOrderAsync(Models.Order order)
    {
         var request = this.GetRestRequest(Method.Post, "orders");
        request.AddJsonBody(order);

        var response = await this.GetClient().ExecuteAsync(request);

        var jsonDoc = ConektaSerializer.ToJsonDocument(response.Content);
        var type = jsonDoc.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {
            var ex =  await GetConektaExceptionAsync(response.Content);
            return Result.Failure<Models.Order, ConektaException>(ex);

        }

        var order_ = await ConektaSerializer.DeserializeAsync<Conekta.Dotnet6.Response.Order>(response.Content);
        Models.Order orderResponse = order_.GetOrder();
        return Result.Success<Models.Order, ConektaException>(orderResponse);

    }

    // CUSTOMERS
    public async Task<Result<Models.Customer, ConektaException>> GetCustomerAsync(string conektaCustomerId)
    {
        var request = this.GetRestRequest(Method.Get, "customers/" + conektaCustomerId);

        var response = await this.GetClient().ExecuteAsync(request);

        var jsonDoc = ConektaSerializer.ToJsonDocument(response.Content);
        var type = jsonDoc.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {

            var ex = await GetConektaExceptionAsync(response.Content);
            return Result.Failure<Models.Customer, ConektaException>(ex);
        }
        var custResponse = await ConektaSerializer.DeserializeAsync<Conekta.Dotnet6.Response.Customer>(response.Content);
        var cust = custResponse.GetCustomer();
        return Result.Success<Models.Customer, ConektaException>(cust);

    }
    public async Task<Result<List<Models.Customer>, ConektaException>> GetCustomersAsync()
    {

        var request = this.GetRestRequest(Method.Get, "customers");
        var response = await this.GetClient().ExecuteAsync(request);
        var jsonDoc = ConektaSerializer.ToJsonDocument(response.Content);
        var type = jsonDoc.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {

            var ex = await GetConektaExceptionAsync(response.Content);
            return Result.Failure<List<Models.Customer>, ConektaException>(new Models.ConektaException("failed"));
        }

        // assumes type is "list"

        int count = jsonDoc.RootElement.GetProperty("total").GetInt32();
        List<Models.Customer> customers = new();

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
                return Result.Failure<List<Models.Customer>, ConektaException>(new Models.ConektaException(ex.Message));
            }


        }
        return Result.Success<List<Models.Customer>, ConektaException>(customers);

    }
    public async Task<Result<Models.Customer, ConektaException>> CreateCustomerAsync(Models.Customer newCust)
    {

        var request = this.GetRestRequest(Method.Post, "customers");
        request.AddJsonBody(newCust);
        var response = await this.GetClient().ExecuteAsync(request);
        var obj = ConektaSerializer.ToJsonDocument(response.Content);
        var type = obj.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {

            var ex = await GetConektaExceptionAsync(response.Content);
            return Result.Failure<Models.Customer, ConektaException>(ex);
        }
        var custResponse = await ConektaSerializer.DeserializeAsync<Conekta.Dotnet6.Response.Customer>(response.Content);
        var cust = custResponse.GetCustomer();
        return Result.Success<Models.Customer, ConektaException>(cust);
    }

    public async Task<Result> DeleteCustomerAsync(string conektaCustomerId)
    {

        var request = this.GetRestRequest(Method.Delete, $"customers/{conektaCustomerId}");
        var response = await this.GetClient().ExecuteAsync(request);
        var obj = ConektaSerializer.ToJsonDocument(response.Content);
        var type = obj.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {
            var ex = await GetConektaExceptionAsync(response.Content);
            return Result.Failure(ex.message);
        }

        return Result.Success();
    }

    // PAYMENT SOURCES
    public async Task<Result<Models.PaymentSource, ConektaException>> CreatePaymentSourceAsync(Models.PaymentSource paySource, string custId)
    {
        var request = this.GetRestRequest(Method.Post, $"customers/{custId}/payment_sources");
        request.AddJsonBody(paySource);
        var response = await this.GetClient().ExecuteAsync(request);
        var jsonDoc = ConektaSerializer.ToJsonDocument(response.Content);
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

    // CHARGES

    public async Task<Result<Models.Charge, ConektaException>> CreateChargeAsync(Models.Charge charge, string conektaOrderId)
    {
        var request = this.GetRestRequest(Method.Post, $"orders/{conektaOrderId}/charges");
        request.AddJsonBody(charge);
        var response = await this.GetClient().ExecuteAsync(request);
        var jsonDoc = ConektaSerializer.ToJsonDocument(response.Content);
        var type = jsonDoc.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {
            var ex = await GetConektaExceptionAsync(response.Content);
            return Result.Failure<Models.Charge, ConektaException>(ex);

        }
        Models.Charge conektaCharge;
        try
        {
            conektaCharge = await ConektaSerializer.DeserializeAsync<Models.Charge>(response.Content);
        }
        catch (Exception ex)
        {

            return Result.Failure<Models.Charge, ConektaException>(new Models.ConektaException(ex.Message));
        }

        return Result.Success<Models.Charge, ConektaException>(conektaCharge);
    }



    // PAYMENT LINK
    public async Task<Result<Models.PaymentLink, ConektaException>> CreatePaymentLinkAsync(Models.PaymentLink paymentLink)
    {

        var request = this.GetRestRequest(Method.Post, "checkouts");
        request.AddBody(paymentLink);
        var response = await this.GetClient().ExecuteAsync(request);
        var jsonDoc = ConektaSerializer.ToJsonDocument(response.Content);
        var type = jsonDoc.RootElement.GetProperty("object").ToString();
        if (type == "error")
        {
            var ex = await GetConektaExceptionAsync(response.Content);
            return Result.Failure<Models.PaymentLink, ConektaException>(ex);
        }
        var paymentLinkResponse = await ConektaSerializer.DeserializeAsync<Models.PaymentLink>(response.Content);
        return Result.Success<Models.PaymentLink, ConektaException>(paymentLinkResponse);

    }

    // --------------------

    private RestRequest GetRestRequest(RestSharp.Method method, string url)
    {
        var request = new RestRequest(url, method);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Accept", "application/vnd.conekta-v" + version + "+json");
        request.AddHeader("Authorization", "Basic " + apiKeyBase64 + ":");
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
