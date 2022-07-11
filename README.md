# Conekta.Dotnet6
Conekta Api for .net 6 using native System.Text.Json

This package for you if:
- You are implementing the [Conekta payment Api](https://developers.conekta.com/reference/autenticaci%C3%B3n) on a backend running .net 6
- You are interested in, or otherwise comfortable with, using the native System.Text.Json serializer for all your json serialization and deserialization needs (no more Newtonsoft.Json)
- You want all your api calls to use the async/await protocol
- You are interested in, or otherwise comfortable with, factoring your code away from relying on exceptions toward a more function approach, specifically, with the use of a Result class as the return response from your api calls.  This approach is explicity relying on the approach developed by [Vladimir Khorikov](https://enterprisecraftmanship.com)  
