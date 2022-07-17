# Conekta.Dotnet6

Conekta Api wrapper for .NET 6 using the native System.Text.Json

This package is for you if:

- You are implementing the [Conekta payment Api](https://developers.conekta.com/reference/autenticaci%C3%B3n) on a backend running .NET 6
- You are interested in, or otherwise comfortable with, relying on the native JsonSerializer serializer for all your json serialization and deserialization needs (no more Newtonsoft.Json). [JsonSerializer](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer?view=net-6.0) from the [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/api/system.text.json?view=net-6.0) package is the default serializer for .NET going forward.
- You are interested in, or otherwise comfortable with, relying on [RestSharp v107+](https://restsharp.dev/v107/#restsharp-v107), which is a major upgrade from previous versions.  This includes relying on the non-blocking async/await protocol for all your api calls.
- You are interested in, or otherwise comfortable with, factoring your code away from relying on exceptions toward a more functional approach, specifically, with the use of a Result class as the return response from your api calls.  I have explicity adopted the helpful approach developed by [Vladimir Khorikov](https://enterprisecraftsmanship.com),
  and there is a hard dependency here on his nuget package [CSharpFunctionalExtensions](https://www.nuget.org/packages/CSharpFunctionalExtensions/). For more on this approach, checkout the following resources:
  - [Applying Functional Principles in C# 6](https://www.pluralsight.com/courses/csharp-applying-functional-principles)
  - [Don't throw exceptions in C#. Do this instead](https://youtu.be/a1ye9eGTB98)

## Installation

Available on [NuGet](https://www.nuget.org/packages/Conekta.Dotnet6)

```bash
dotnet add package Conekta.Dotnet6
```

or

```powershell
PM> Install-Package Conekta.Dotnet6
```

## Setup

### In program.cs or startup.cs

ConektaRestClient should be registered as a singleton, following [RestSharp best practices](https://restsharp.dev/v107/#restclient-lifecycle)

```csharp
builder.Services.AddSingleton<IConektaRestClient>(new ConektaRestClient());
```

Configure the JsonSerializer to accept trailing commas just in case.

```csharp
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.AllowTrailingCommas = true;

    });
```

## API Example

### Get Customer

```csharp
using Conekta.Dotnet6;
using ConektaModels = Conekta.Dotnet6.Models;
using CSharpFunctionalExtensions;

// private readonly IConektaRestClient _conektaRestClient; <==Dependency Injected
var conektaApi = new ConektaApi("en", "your_conekta_private_key", _conektaRestClient);
        
Result<ConektaModels.Customer, ConektaModels.ConektaException> customer = await conektaApi.GetCustomerAsync(id);
if (customer.IsFailure)
   {
     // Error will be the ConektaException class
     return Content(customer.Error.message);
   }

// If the api call is successful, customer.Value will be the Customer class
return Json(customer.Value);
```

Full examples [here](https://github.com/brendanalexdr/Conekta.Dotnet6/blob/main/src/DemoWebApi/Controllers/HomeController.cs)

## Value Objects

A number of value objects have been created to help manage a few of the peculiarities of the conekta api.  If you are not familiar with value obects in .net, you can check out [this link](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects).

The important thing to remember is that you do not need to worry about the serialization of these value objects.  Custom [JsonConverters](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-converters-how-to?pivots=dotnet-6-0) have been created for each value object to property handle the serialization and deserialization.

