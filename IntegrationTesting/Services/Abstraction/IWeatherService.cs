using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTesting.Services.Abstraction
{
   public interface IWeatherService
   {
      public IEnumerable<WeatherForecast> Get();
   }
}
