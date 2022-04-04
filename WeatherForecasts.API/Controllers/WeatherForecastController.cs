using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

using WeatherForecasts.Application.Contracts.Services;
using WeatherForecasts.Application.Services;
using WeatherForecasts.Core;

namespace WeatherForecasts.API.Controllers;

[ApiController]
[Route("weatherforecast")]
public class WeatherForecastController : ControllerBase {
  private readonly ILogger<WeatherForecastController> forecastLogger;
  private readonly IWeatherForecastService forecastService;

  public WeatherForecastController(IWeatherForecastService service, ILogger<WeatherForecastController> logger)
    => (forecastService, forecastLogger) = (service, logger);

  [HttpGet(Name = "GetWeatherForecast")]
  public ActionResult<IList<WeatherForecast>> GetWeatherForecasts() {
    forecastLogger.LogInformation("Request received by controller: {Controller}, with action: {ControllerAction}", nameof(WeatherForecastController), nameof(GetWeatherForecasts));
    forecastLogger.LogInformation("Dispatchin to service: {Service}", nameof(WeatherForecastService));

    var stopWatch = new Stopwatch();

    stopWatch.Start();
    var result = forecastService.ProcessFarenheitTemperature();
    stopWatch.Stop();

    forecastLogger.LogInformation("{Service} generated a response in: {ElapsedTime}ms", nameof(WeatherForecastService), stopWatch.ElapsedMilliseconds);
    forecastLogger.LogInformation("We got {Count} forecasts from the service", result.Count);

    return Ok(result);
  }
}
