using Microsoft.EntityFrameworkCore;
using server.Model;
using System.Collections.Generic;
using server.Model;

namespace server.Data
{
    public class WeatherForecastContext : DbContext
    {
        public WeatherForecastContext(DbContextOptions<WeatherForecastContext> options) : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }  // DbSet za WeatherForecast
    }
}
