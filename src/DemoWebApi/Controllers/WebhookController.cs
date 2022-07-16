using Conekta.Dotnet6;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ConektaValues = Conekta.Dotnet6.Values;

namespace DemoWebApi.Controllers
{

    // Go here for a sample webhook payload for testing:
    // https://developers.conekta.com/reference/eventos
    public class WebhookController : Controller
    {
        [HttpPost("conekta/event")]
        public async Task<IActionResult> PostWebhookAsync()
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
                var eventItems = root.EnumerateArray();
                foreach (var item in eventItems)
                {
                    await LogWebhookAsync(item);

                }
               
            }
            if (root.ValueKind == JsonValueKind.Object)
            {

                await LogWebhookAsync(root);
            }
            return new OkResult();
        }


        private async Task<Result> LogWebhookAsync(JsonElement webhookBody)
        {

            var @object = await ConektaSerializer.DeserializeAsync<Conekta.Dotnet6.Response.Webhook>(webhookBody.ToString());

            var webhookEvent = @object.GetEvent();


            var eventType = webhookEvent.Type;

            if (eventType == ConektaValues.ConektaEventType.ChargePaid)
            {
                // do something...

            }
            if (eventType == ConektaValues.ConektaEventType.ChargeRefunded)
            {
                // do something...

            }

            return Result.Success();
        }
    }
}
