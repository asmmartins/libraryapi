﻿using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace Library.Tests.Integration
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() => new Fixture().Customize(new CompositeCustomization(new AutoMoqCustomization(), new SupportMutableValueTypesCustomization())))
        {
        }
    }
}