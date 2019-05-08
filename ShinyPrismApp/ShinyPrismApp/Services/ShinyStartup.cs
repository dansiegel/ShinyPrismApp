using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Shiny.Locations;
using System;
using System.Collections.Generic;
using System.Text;
using Prism.Ioc;
using Prism.DryIoc;

namespace ShinyPrismApp.Services
{
    public class ShinyStartup : Startup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.UseGpsBackground<GpsDelegate>();
        }

        public override IServiceProvider CreateServiceProvider(IServiceCollection services)
        {
            return PrismContainerExtension.Current.CreateServiceProvider(services);
        }
    }
}
