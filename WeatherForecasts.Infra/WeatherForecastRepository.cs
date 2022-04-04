using WeatherForecasts.Application.Contracts.Repositories;
using WeatherForecasts.Core;

namespace WeatherForecasts.Infra;

public class WeatherForecastRepository : IWeatherForecastRepository {
  private static readonly string[] summaries = new[] {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
  };

  public IList<WeatherForecast> GetForecasts() {
    var random = new Random();

    return Enumerable
      .Range(1, 5)
      .Select(i => new WeatherForecast {
        Date = DateTime.Now.AddDays(i),
        TemperatureCelsius = random.Next(-20, 55),
        Summary = summaries[random.Next(summaries.Length)]
      })
      .ToList();
  }
}
