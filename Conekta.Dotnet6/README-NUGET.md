# Conekta.Dotnet6
Conekta Api for .NET 6 using the native System.Text.Json

This package is for you if:
- You are implementing the [Conekta payment Api](https://developers.conekta.com/reference/autenticaci%C3%B3n) on a backend running .NET 6
- You are interested in, or otherwise comfortable with, using the native JsonSerializer serializer for all your json serialization and deserialization needs (no more Newtonsoft.Json). [JsonSerializer](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer?view=net-6.0) from the [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/api/system.text.json?view=net-6.0) package is the default serializer for .NET going forward.
- You are interested in, or otherwise comfortable with, using [RestSharp v107+](https://restsharp.dev/v107/#restsharp-v107), which is a major upgrade from previous versions.  This includes relying on the async/await protocol for all your api calls.
- You are interested in, or otherwise comfortable with, factoring your code away from relying on exceptions toward a more function approach, specifically, with the use of a Result class as the return response from your api calls.  I have explicity adopted the helpful approach developed by [Vladimir Khorikov](https://enterprisecraftsmanship.com), 
and there is a hard dependency here on his nuget package [CSharpFunctionalExtensions](https://www.nuget.org/packages/CSharpFunctionalExtensions/). For more on this approach, checkout the following resources:
  - [Applying Functional Principles in C# 6](https://www.pluralsight.com/courses/csharp-applying-functional-principles)
  - [Don't throw exceptions in C#. Do this instead](https://youtu.be/a1ye9eGTB98)

For more information about this package, including how to install and utilize, please refer to the github repository:  [https://github.com/brendanalexdr/Conekta.Dotnet6](https://github.com/brendanalexdr/Conekta.Dotnet6)