using FluentAssertions;
using Library.Api;
using System;
using Xunit;

namespace Library.Tests.Unit.Api
{
    public class ProgramTests
    {
        [Fact]
        public void CreateHost_ShouldNotThrow()
        {
            Action action = () => Program.CreateHostBuilder(null).Build();

            // Asserts
            action.Should().NotThrow();
        }
    }
}
