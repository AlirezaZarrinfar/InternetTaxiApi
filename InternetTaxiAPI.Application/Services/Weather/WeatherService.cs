using System;

namespace InternetTaxiAPI.Application.Services.Weather
{
    public class WeatherService : IWeatherService
    {
        public int GetTemp()
        {
            Random random = new Random();
            int number = random.Next(10, 31);
            return number;
        }
    }
}
