using FluentAssertions;
using Library.Api.Configuration.Options;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Xunit;

namespace Library.Tests.Unit.Api.Configuration.Options
{
    public class CorsOptionsFactoryTests
    {
        [Theory, AutoMoqData]
        public void Create_ReturnsCorsOptions(CorsOptions options)
        {
            var action = CorsOptionsFactory.Create();

            action.Invoke(options);

            // Asserts
            options.GetPolicy("CorsPolicy").Should().NotBeNull();
        }
    }
}
