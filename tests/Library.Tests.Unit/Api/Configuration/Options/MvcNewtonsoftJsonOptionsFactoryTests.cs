﻿using FluentAssertions;
using Library.Api.Configuration.Options;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;
using Xunit;

namespace Library.Tests.Unit.Api.Configuration.Options
{
    public class MvcNewtonsoftJsonOptionsFactoryTests
    {
        [Theory, AutoMoqData]
        public void Create_ReturnsMvcNewtonsoftJsonOptions(MvcNewtonsoftJsonOptions options)
        {
            var action = MvcNewtonsoftJsonOptionsFactory.Create();

            action.Invoke(options);

            // Asserts
            options.SerializerSettings.Converters.OfType<StringEnumConverter>().Should().NotBeEmpty();
            options.SerializerSettings.NullValueHandling.Should().Be(NullValueHandling.Ignore);
        }
    }
}
