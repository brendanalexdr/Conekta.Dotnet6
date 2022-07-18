using ConektaDotnet6;
using ConektaDotnet6.Values;
using CSharpFunctionalExtensions;
using DemoWebApi.Config;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DemoWebApi.Controllers
{

    // Go here for a sample webhook payload for testing:
    // https://developers.conekta.com/reference/eventos
    public class WebhookController : Controller
    {
        private readonly IConektaRestClient _conektaRestClient;
        private readonly ConektaPrivateKey _conektaPrivateKey;

        public WebhookController(IConektaRestClient conektaRestClient, ConektaPrivateKey conektaPrivateKey)
        {
            _conektaRestClient = conektaRestClient;
            _conektaPrivateKey = conektaPrivateKey;
        }

        // use this endpoint to create a new webhook config with Conekta
        [HttpPost("webhook")]
        public async Task<ActionResult> CreateWebhookAsync([FromBody] ConektaDotnet6.Models.Webhook webhook)
        {

            var conektaApi = new ConektaApi("en", _conektaPrivateKey.Value, _conektaRestClient);

            var result = await conektaApi.CreateWebhookAsync(webhook);
            if (result.IsFailure)
            {
                return new BadRequestResult();
            }


            return new OkResult();

        }

        //use this enpoint to consume webhook events from Conekta
        [HttpPost("conekta/events")]
        public async Task<IActionResult> PostWebhookEventsAsync()
        {
            if (Request.Body == null)
            {
                return new BadRequestResult();
            }
            Maybe<string> json = null;

            using (var reader = new StreamReader(Request.Body))
            {
                json = await reader.ReadToEndAsync();
                if (string.IsNullOrEmpty(json.Value))
                {
                    json = null;
                }

            }
            if (json.HasNoValue)
            {

                return new BadRequestResult();
            }

            var requestBody = ConektaSerializer.ToJsonDocument(json.Value);
            var root = requestBody.RootElement;
            if (root.ValueKind == System.Text.Json.JsonValueKind.Array)
            {
                // in this case Conekta has aggregated 2 or more events into one webhook payload

                var eventItems = root.EnumerateArray();
                foreach (var item in eventItems)
                {
                    await ProcessWebhookEvent(item);

                }
               
            }
            if (root.ValueKind == JsonValueKind.Object)
            {

                await ProcessWebhookEvent(root);
            }
            return new OkResult();
        }

        private async Task<Result> ProcessWebhookEvent(JsonElement eventBody)
        {

            var obj = await ConektaSerializer.DeserializeAsync<ConektaDotnet6.Response.Webhook>(eventBody.ToString());

            var webhookEvent = obj.GetEvent();

            var eventType = webhookEvent.Type;

            if (eventType == ConektaEventType.ChargePaid)
            {

                var charge = await ConektaSerializer.DeserializeAsync<ConektaDotnet6.Models.Charge>(webhookEvent.Object.RootElement.ToString());
                // do something...               

            }
            if (eventType == ConektaEventType.ChargeChargebackCreated)
            {
                // do something...

            }

            return Result.Success();
        }
    }
}
