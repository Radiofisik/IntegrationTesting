using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using IntegrationTesting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace Tests
{
   class TestWebApplicationFactory: WebApplicationFactory<Startup>
   {
      private Action<ContainerBuilder> _setupMockServicesAction;

      public TestWebApplicationFactory WithMockServices(Action<ContainerBuilder> setupMockServices)
      {
         _setupMockServicesAction = setupMockServices;
         return this;
      }

      protected override IHost CreateHost(IHostBuilder builder)
      {
         builder.ConfigureContainer<ContainerBuilder>(containerBuilder =>
         {
            _setupMockServicesAction?.Invoke(containerBuilder);
         });

         return base.CreateHost(builder);
      }
   }
}
