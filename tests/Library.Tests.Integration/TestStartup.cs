using AutoMapper;
using Library.Infra.Ioc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace Library.Tests.Integration
{
    public class TestStartup : DependencyInjectionTestFramework
    {
        public TestStartup(IMessageSink messageSink) : base(messageSink) { }

        protected void ConfigureApp(IConfigurationBuilder builder)
        {
            builder.AddJsonFile("appsettings.json")
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .Build();
        }

        protected void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddDependecyInjection(configuration);
        }

        protected override IHostBuilder CreateHostBuilder(AssemblyName assemblyName) =>
            base.CreateHostBuilder(assemblyName)
                .UseEnvironment("Testing")
                .ConfigureAppConfiguration(ConfigureApp)
                .ConfigureServices((context, services) => { ConfigureServices(services, context.Configuration); });
    }
}
