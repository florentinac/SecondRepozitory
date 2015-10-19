using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherForecast
{
    public class WeatherForecast
    {
        public struct WeatherDays
        {
            public string Month;
            public string Day;
            public int MaxTemperature;
            public int MinTemperature;

        };
        public static int GetMaxVaule(WeatherDays[] weather)
        {
            var maxValue = weather[0].MinTemperature;
            for (var i = 0; i < weather.Length; i++)
            {
                if (weather[i].MaxTemperature >= maxValue)
                    maxValue = weather[i].MaxTemperature;
            }
            return maxValue;
        }

        public static int GetMinValue(WeatherDays[] weather)
        {
            var minValue = weather[0].MaxTemperature;
            for (var i = 0; i < weather.Length; i++)
            {
                if (weather[i].MaxTemperature <= minValue)
                    minValue = weather[i].MaxTemperature;
            }
            return minValue;
        }

        public static int GetTotalValue(WeatherDays[] weather, string month)
        {
            var totalValue = 0;
            for (var i = 0; i < weather.Length; i++)
                if (weather[i].Month == month)
                    totalValue += weather[i].MaxTemperature;
            return totalValue;
        }

        public static float GetAveregeTemperature(WeatherDays[] weather, string month)
        {
            float averegeTemperature = 0;
            var index = 0;
            float totalOfMaxTemperature = GetTotalValue(weather, month);
            for (var i = 0; i < weather.Length; i++)
                if (weather[i].Month == month)
                    index++;
            averegeTemperature = totalOfMaxTemperature / index;
            return averegeTemperature;
        }
        public static WeatherDays[] AddToArray(ref WeatherDays[] array, WeatherDays newValue)
        {
            array = ResizeArray(array, 1);
            array[array.Length - 1] = newValue;
            return array;
        }

        public static WeatherDays[] ResizeArray(WeatherDays[] oldArray, int difference)
        {
            var newArray = new WeatherDays[oldArray.Length + difference];
            for (var i = 0; i < oldArray.Length; i++)
                newArray[i] = oldArray[i];
            return newArray;
        }

        public static WeatherDays[] GetTheHottestDay(WeatherDays[] weather)
        {
            var maxOfMaxTemperature = GetMaxVaule(weather);
            var dayWithMaxTemperature = new WeatherDays[0];
            for (var i = 0; i < weather.Length; i++)
                if (weather[i].MaxTemperature == maxOfMaxTemperature)
                    dayWithMaxTemperature = AddToArray(ref dayWithMaxTemperature, weather[i]);
            return dayWithMaxTemperature;
        }

        public static WeatherDays[] GetTheColdexDay(WeatherDays[] weather)
        {
            var minOfMaxTemperature = GetMinValue(weather);
            var dayWithMinOfMaxTemperature = new WeatherDays[0];
            for (var i = 0; i < weather.Length; i++)
                if (weather[i].MaxTemperature == minOfMaxTemperature)
                    dayWithMinOfMaxTemperature = AddToArray(ref dayWithMinOfMaxTemperature, weather[i]);
            return dayWithMinOfMaxTemperature;
        }

        public static int GetMaxDifference(WeatherDays[] weather)
        {
            var maxDifference = weather[0].MaxTemperature - weather[0].MinTemperature;
            for (var i = 0; i < weather.Length; i++)
            {
                var difference = weather[i].MaxTemperature - weather[i].MinTemperature;
                if (difference > maxDifference)
                    maxDifference = difference;
            }
            return maxDifference;
        }
    }
}
