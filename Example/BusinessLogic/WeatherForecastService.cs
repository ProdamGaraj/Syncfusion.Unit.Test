using Example.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Example.DataRepository
{
    public class WeatherForecastService
    {
        private IEntityRepository<WeatherForecast> _weatherForecastRepository { get; set; }
        public WeatherForecastService(IEntityRepository<WeatherForecast> weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public virtual List<WeatherForecast> GetActiveWeathers()
        {
            var result = new List<WeatherForecast>();

            result = _weatherForecastRepository.GetAllQueryable().ToList();

            return result;
        }
    }

}