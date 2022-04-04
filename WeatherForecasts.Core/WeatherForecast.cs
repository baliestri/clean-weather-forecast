namespace WeatherForecasts.Core;

public class WeatherForecast {
  public DateTime Date { get; set; }
  public int TemperatureCelsius { get; set; }
  public int TemperatureFahrenheit { get; set; }
  public string Summary { get; set; } = default!;
}
