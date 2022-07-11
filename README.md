# Conekta.Dotnet6
Conekta Api for .net 6 using native System.Text.Json

This package is for you if:
- You are implementing the [Conekta payment Api](https://developers.conekta.com/reference/autenticaci%C3%B3n) on a backend running .net 6
- You are interested in, or otherwise comfortable with, using the native System.Text.Json serializer for all your json serialization and deserialization needs (no more Newtonsoft.Json)
- You want all your api calls to use the async/await protocol
- You want to use [RestSharp v107+](https://restsharp.dev/v107/#restsharp-v107), which is a major upgrade, and contained lot of breaking changes.  
- You are interested in, or otherwise comfortable with, factoring your code away from relying on exceptions toward a more function approach, specifically, with the use of a Result class as the return response from your api calls.  I have explicity adopted the helpful approach developed by [Vladimir Khorikov](https://enterprisecraftmanship.com), 
and there is a hard dependency here on his nuget package [CSharpFunctionalExtensions](https://www.nuget.org/packages/CSharpFunctionalExtensions/). For more on this approach, checkout the following resources:
  - [Applying Functional Principles in C# 6](https://www.pluralsight.com/courses/csharp-applying-functional-principles)
  - [Don't throw exceptions in C#. Do this instead](https://youtu.be/a1ye9eGTB98)