namespace ESIN.Clinic.Api.WeatherForecasts;

public static class WeatherForecastEndpoints
{
    public static void RegisterWeatherForecastEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/weatherforecast", () =>
            {
                List<string> summaries =
                [
                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                ];

                WeatherForecast[] forecast = Enumerable.Range(1, 5)
                    .Select(index =>
                                new WeatherForecast
                                (
                                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                                    Random.Shared.Next(-20, 55),
                                    summaries[Random.Shared.Next(summaries.Count)]))
                    .ToArray();

                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();
    }
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}