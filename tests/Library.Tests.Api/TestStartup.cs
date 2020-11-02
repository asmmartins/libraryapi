using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Library.Infra.Ioc;
using System.Reflection;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace Library.Tests.Api
{
    public class TestStartup : DependencyInjectionTestFramework
    {
        public TestStartup(IMessageSink messageSink) : base(messageSink) { }

        protected void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddSingleton<ITestHost, TestHost>();
        }

        protected override IHostBuilder CreateHostBuilder(AssemblyName assemblyName) =>
            base.CreateHostBuilder(assemblyName)
                .UseEnvironment("Testing")
                .ConfigureServices(ConfigureServices);
    }
}
