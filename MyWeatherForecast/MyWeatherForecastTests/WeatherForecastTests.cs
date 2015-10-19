using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyWeatherForecast.Tests
{
    [TestClass]
    public class WeatherForecastTests
    {
        public WeatherForecast.WeatherDays[] WeatherDays = new WeatherForecast.WeatherDays[]
        {
            new WeatherForecast.WeatherDays {Month ="Mai", Day="Sunday", MaxTemperature=20,MinTemperature=15},
            new WeatherForecast.WeatherDays {Month ="Mai", Day="Monday", MaxTemperature=20,MinTemperature=8},
            new WeatherForecast.WeatherDays {Month ="March", Day="Tuesday", MaxTemperature=16,MinTemperature=7},
            new WeatherForecast.WeatherDays {Month ="November", Day="Wednesday", MaxTemperature=15,MinTemperature=10},
            new WeatherForecast.WeatherDays {Month ="November", Day="Thursday", MaxTemperature=13,MinTemperature=8},
            new WeatherForecast.WeatherDays {Month ="November", Day="Friday", MaxTemperature=14,MinTemperature=9},
            new WeatherForecast.WeatherDays {Month ="November", Day="Saturday", MaxTemperature=13,MinTemperature=5}
        };

        public WeatherForecast.WeatherDays[] HottestDays = new WeatherForecast.WeatherDays[]
        {
            new WeatherForecast.WeatherDays {Month ="Mai", Day="Sunday", MaxTemperature=20,MinTemperature=15},
            new WeatherForecast.WeatherDays {Month ="Mai", Day="Monday", MaxTemperature=20,MinTemperature=8}
        };

        public WeatherForecast.WeatherDays[] ColdexDays = new WeatherForecast.WeatherDays[]
        {
            new WeatherForecast.WeatherDays {Month ="November", Day="Thursday", MaxTemperature=13,MinTemperature=8},
            new WeatherForecast.WeatherDays {Month ="November", Day="Saturday", MaxTemperature=13,MinTemperature=5}
        };

        public WeatherForecast.WeatherDays[] NewWeatherDays = new WeatherForecast.WeatherDays[]
        {
            new WeatherForecast.WeatherDays {Month ="Mai", Day="Sunday", MaxTemperature=20,MinTemperature=15},
            new WeatherForecast.WeatherDays {Month ="Mai", Day="Monday", MaxTemperature=20,MinTemperature=8},
            new WeatherForecast.WeatherDays {Month ="March", Day="Tuesday", MaxTemperature=16,MinTemperature=7},
            new WeatherForecast.WeatherDays {Month ="November", Day="Wednesday", MaxTemperature=15,MinTemperature=10},
            new WeatherForecast.WeatherDays {Month ="November", Day="Thursday", MaxTemperature=13,MinTemperature=8},
            new WeatherForecast.WeatherDays {Month ="November", Day="Friday", MaxTemperature=14,MinTemperature=9},
            new WeatherForecast.WeatherDays {Month ="November", Day="Saturday", MaxTemperature=13,MinTemperature=5},
            new WeatherForecast.WeatherDays {Month ="November", Day="Sunday", MaxTemperature=18,MinTemperature=11}
        };

        [TestMethod]
        public void MaxDifferenceBetweenTheMaxAndMinTemperature()
        {
            var expectedDifference = 12;
            var actualDifference = WeatherForecast.GetMaxDifference(WeatherDays);
            Assert.AreEqual(expectedDifference, actualDifference);
        }

        [TestMethod]
        public void AddANewWeatherInWeatherDay()
        {
            var newWeather = new WeatherForecast.WeatherDays { Month = "November", Day = "Sunday", MaxTemperature = 18, MinTemperature = 11 };
            var expectedProduct = NewWeatherDays;
            var actualProduct = WeatherForecast.AddToArray(ref WeatherDays, newWeather);
            CollectionAssert.AreEqual(expectedProduct, actualProduct);
        }

        [TestMethod]
        public void HottestDaysWithSameMaxTemperature()
        {
            var expectedProduct = HottestDays;
            var actualProduct = WeatherForecast.GetTheHottestDay(WeatherDays);
            CollectionAssert.AreEqual(expectedProduct, actualProduct);
        }

        [TestMethod]
        public void ColdexDaysWithSameMaxTemperature()
        {
            var expectedProduct = ColdexDays;
            var actualProduct = WeatherForecast.GetTheColdexDay(WeatherDays);
            CollectionAssert.AreEqual(expectedProduct, actualProduct);
        }

        [TestMethod]
        public void AveregeTemperature()
        {
            var expectedProduct = 13.75;
            var actualProduct = WeatherForecast.GetAveregeTemperature(WeatherDays, "November");
            Assert.AreEqual(expectedProduct, actualProduct);
        }
    }
}
