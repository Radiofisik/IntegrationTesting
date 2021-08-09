using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using IntegrationTesting;
using IntegrationTesting.Services.Abstraction;
using Moq;
using Xunit;

namespace Tests
{
   public class UnitTest1
   {
      [Fact]
      public async Task WeatherControllerTest()
      {
         var mock = new Mock<IWeatherService>();
         mock.Setup(e => e.Get()).Returns(new List<WeatherForecast>());

         using var testWebApplicationFactory = new TestWebApplicationFactory()
            .WithMockServices(containerBuilder =>
            {
               containerBuilder.Register(s => mock.Object).AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
            });

         var resp = await testWebApplicationFactory.CreateClient().GetAsync("/weatherforecast");

         resp.StatusCode.Should().Be(HttpStatusCode.OK);
         var result = await resp.Content.ReadAsStringAsync();
         result.Should().Be("[]");

         mock.Verify(m=>m.Get(), Times.AtLeastOnce);
      }
   }
}
