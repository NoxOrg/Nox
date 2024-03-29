﻿using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using AutoFixture;


namespace Nox.Integration.Tests.FixtureConfig
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(CreateFixture)
        {
        }

        private static IFixture CreateFixture()
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            return fixture;
        }
    }
}
