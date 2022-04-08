using Example.Controllers;
using Example.DataAccess;
using Example.DataRepository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Tests
{
    public class WeatherForecastTestBL
    {
        private Mock<IEntityRepository<WeatherForecast>> weatherForecastRepositoryMock;
        private Mock<WeatherForecastService> weatherForecastServiceMock;
        private List<WeatherForecast> weatherForecasts;

        [SetUp]
        public void Setup()
        {
            //Set up the mock
            weatherForecastRepositoryMock = new Mock<IEntityRepository<WeatherForecast>>();
            weatherForecastServiceMock = new Mock<WeatherForecastService>(weatherForecastRepositoryMock.Object);
            weatherForecasts = new List<WeatherForecast>();
            weatherForecasts.Add(new WeatherForecast()
            {
                Id = 1,
                Date = DateTime.Now,
                TemperatureC = 26,
                Summary = "Cool"
            });

            weatherForecasts.Add(new WeatherForecast()
            {
                Id = 2,
                Date = DateTime.Now,
                TemperatureC = 34,
                Summary = "Balmy"
            });

            weatherForecasts.Add(new WeatherForecast()
            {
                Id = 3,
                Date = DateTime.Now,
                TemperatureC = 20,
                Summary = "Hot"
            });

            weatherForecasts.Add(new WeatherForecast()
            {
                Id = 4,
                Date = DateTime.Now,
                TemperatureC = 25,
                Summary = "Warm"
            });
            weatherForecasts.Add(new WeatherForecast()
            {
                Id = 5,
                Date = DateTime.Now,
                TemperatureC = 21,
                Summary = "Sweltering"
            });
        }

        [Test]
        public void TestGetActiveRecords()
        {
            //Act
            weatherForecastRepositoryMock.Setup(a => a.GetAllQueryable()).Returns(weatherForecasts.AsQueryable());
            weatherForecastServiceMock.Setup(b => b.GetActiveWeathers()).Returns(weatherForecastRepositoryMock.Object.GetAllQueryable().ToList());
            var weatherForecastService = weatherForecastServiceMock.Object;

            //Arrange
            var weatherForecastController = new WeatherForecastController(weatherForecastService);
            var weatherForecastsEnumerable = weatherForecastController.Get();
            var weatherForecastsList = weatherForecastsEnumerable.ToList();

            //Arrest
            Assert.IsTrue(weatherForecastsList.Count == 5);
            Assert.That(weatherForecastsList[0].Id == 1);
            Assert.That(weatherForecastsList[1].Summary == "Balmy");
            Assert.That(weatherForecastsList[2].TemperatureC == 20);
            Assert.IsTrue(weatherForecastsList[3].Date != DateTime.Parse("23.06.2000"));
        }
    }

}
