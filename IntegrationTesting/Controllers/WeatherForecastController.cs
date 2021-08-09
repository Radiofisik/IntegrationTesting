using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationTesting.Services.Abstraction;

namespace IntegrationTesting.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class WeatherForecastController : ControllerBase
   {

      private readonly IWeatherService _service;
      private readonly ILogger<WeatherForecastController> _logger;

      public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService service)
      {
         _logger = logger;
         _service = service;
      }

      [HttpGet]
      public IEnumerable<WeatherForecast> Get()
      {
         return _service.Get();
      }
   }
}
