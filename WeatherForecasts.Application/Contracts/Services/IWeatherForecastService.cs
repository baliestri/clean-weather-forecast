using WeatherForecasts.Core;

namespace WeatherForecasts.Application.Contracts.Services;

public interface IWeatherForecastService {
  IList<WeatherForecast> ProcessFarenheitTemperature();
}
