﻿using FluentAssertions;
using Library.Api.Configuration.Options;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Linq;
using Xunit;
using Xunit.DependencyInjection;

namespace Library.Tests.Unit.Api.Configuration.Options
{
    public class SwaggerUiOptionsFactoryTests
    {
        [Theory]
        [AutoMoqData]
        public void Create_ReturnsSwaggerUIOptions([FromServices] IConfiguration config)
        {
            var options = new SwaggerUIOptions();
            var action = SwaggerUiOptionsFactory.Create(config);

            action.Invoke(options);

            // Asserts
            options.ConfigObject.DocExpansion.Should().Be(DocExpansion.None);
            options.ConfigObject.Urls.Should().NotBeEmpty();
            options.ConfigObject.Urls.FirstOrDefault().Name.Should().NotBeNullOrEmpty();
            options.ConfigObject.Urls.FirstOrDefault().Url.Should().NotBeNullOrEmpty();
        }
    }
}
