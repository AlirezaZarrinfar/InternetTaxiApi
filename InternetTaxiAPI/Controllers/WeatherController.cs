using InternetTaxiAPI.Application.Services.Weather;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        [HttpGet("{City}")]
        public IActionResult Get (string City)
        {
            var res = _weatherService.GetTemp();
            return Ok(res);
        }
    }
}
