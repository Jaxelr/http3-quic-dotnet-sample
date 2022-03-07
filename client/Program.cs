using System.Net;
using System.Net.Http.Json;

using var client = new HttpClient();
client.DefaultRequestVersion = HttpVersion.Version30;

// The client falls back to HTTP2 or HTTP1 if HTTP3 is not supported
client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrLower;

// Will use HTTP3 if the server supports it
var data = await client.GetFromJsonAsync<IEnumerable<WeatherForecast>>("https://localhost:5001/weatherforecast");

if (data != null)
{
    foreach (var item in data)
    {
        Console.WriteLine(item.TemperatureC);
        Console.WriteLine(item.Summary);
        Console.WriteLine(item.Date);
    }
}

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary);