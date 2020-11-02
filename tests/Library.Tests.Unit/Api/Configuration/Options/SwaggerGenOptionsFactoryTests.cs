﻿using FluentAssertions;
using Library.Api.Configuration.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Xunit;

namespace Library.Tests.Unit.Api.Configuration.Options
{
    public class SwaggerGenOptionsFactoryTests
    {
        [Fact]
        public void Create_ReturnsSwaggerGenOptions()
        {
            var options = new SwaggerGenOptions();
            var action = SwaggerGenOptionsFactory.Create();

            action.Invoke(options);

            // Asserts
            options.SwaggerGeneratorOptions.DescribeAllParametersInCamelCase.Should().BeTrue();
        }
    }
}
