using Microsoft.EntityFrameworkCore;

namespace Example.DataRepository
{
    public class ForecastDbContext : DbContext
    {
        public ForecastDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<WeatherForecast> WeatherForecast{ get; set; }
    }
}
