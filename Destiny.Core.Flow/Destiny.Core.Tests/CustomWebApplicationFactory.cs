﻿using Destiny.Core.Flow.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Destiny.Core.Flow.Extensions;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using System.Runtime.Loader;
using Microsoft.AspNetCore.Mvc.Testing;
using Destiny.Core.Flow.Dependency;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Destiny.Core.Flow.Reflection;
using Microsoft.AspNetCore.Hosting;

namespace Destiny.Core.Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public IServiceCollection IServiceCollection { get; private set; }
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            var bulild = new WebHostBuilder().UseStartup<TestStartup>();
            return bulild;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IDependencyProvide, DependencyProvide>();
                // Remove the app's ApplicationDbContext registration.
                var dependency = services.BuildServiceProvider().GetService<IDependencyProvide>();
                dependency.BulkIntoServices(services);
                IServiceCollection = services;
            });
        }
     
       
    }




 


}
