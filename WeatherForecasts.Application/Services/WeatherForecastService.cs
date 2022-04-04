using Microsoft.Extensions.Logging;

using WeatherForecasts.Application.Contracts.Repositories;
using WeatherForecasts.Application.Contracts.Services;
using WeatherForecasts.Core;

namespace WeatherForecasts.Application.Services;

public class WeatherForecastService : IWeatherForecastService {
  private readonly IWeatherForecastRepository forecastRepository;
  private readonly ILogger<WeatherForecastService> forecastLogger;

  public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository, ILogger<WeatherForecastService> logger)
    => (forecastRepository, forecastLogger) = (weatherForecastRepository, logger);

  public IList<WeatherForecast> ProcessFarenheitTemperature() {
    forecastLogger.LogInformation("Getting data from the repository");
    var forecasts = forecastRepository.GetForecasts();

    forecastLogger.LogInformation("Start processing the forecasts");
    var processed = new List<WeatherForecast>();

    for (var i = 0; i < forecasts.Count; i++) {
      forecasts[i].TemperatureFahrenheit = 32 + (int)(forecasts[i].TemperatureCelsius / 0.5556);
      processed.Add(forecasts[i]);
    }

    forecastLogger.LogInformation("Returning results to the caller");
    return processed;
  }
}
