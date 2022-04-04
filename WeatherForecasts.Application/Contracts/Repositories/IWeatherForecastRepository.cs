using WeatherForecasts.Core;

namespace WeatherForecasts.Application.Contracts.Repositories;

public interface IWeatherForecastRepository {
  IList<WeatherForecast> GetForecasts();
}
