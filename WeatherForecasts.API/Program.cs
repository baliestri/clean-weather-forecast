using WeatherForecasts.Application.Contracts.Repositories;
using WeatherForecasts.Application.Contracts.Services;
using WeatherForecasts.Application.Services;
using WeatherForecasts.Infra;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
services.AddScoped<IWeatherForecastService, WeatherForecastService>();

var app = builder.Build();
var env = app.Environment;

if (env.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();