using FluentAssertions;
using Nox.Domain;
using Nox.Types;

namespace Nox.Lib.Tests.Domain
{
    public class AuditableEntityBaseTests
    {
        private class SampleEntity : AuditableEntityBase { }

        private static readonly string DefaultUser = "N/A";
        private static readonly string DefaultSystem = "N/A";

        private static readonly System.DateTime CurrentDateTimeUtc = System.DateTime.UtcNow;
        private static readonly TimeSpan DefaultDateTimePrecision = TimeSpan.FromSeconds(15);

        [Fact]
        public void Constructor_Default_ReturnsDefaultAuditCreatedProperties()
        {
            var entity = new SampleEntity();

            entity.CreatedAtUtc.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
            entity.CreatedBy.Should().BeEquivalentTo(DefaultUser);
            entity.CreatedVia.Should().BeEquivalentTo(DefaultSystem);

            entity.LastUpdatedAtUtc.Should().BeNull();
            entity.LastUpdatedBy.Should().BeNull();
            entity.LastUpdatedVia.Should().BeNull();

            entity.DeletedAtUtc.Should().BeNull();
            entity.DeletedBy.Should().BeNull();
            entity.DeletedVia.Should().BeNull();
        }

        [Fact]
        public void Created_WithSpecifiedUserAndSystem_SetsAuditCreatedProperties()
        {
            var entity = new SampleEntity();

            var user = "someone@example.com";
            var system = "some system";
            entity.Created(user, system);

            entity.CreatedAtUtc.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
            entity.CreatedBy.Should().BeEquivalentTo(user);
            entity.CreatedVia.Should().BeEquivalentTo(system);

            entity.LastUpdatedAtUtc.Should().BeNull();
            entity.LastUpdatedBy.Should().BeNull();
            entity.LastUpdatedVia.Should().BeNull();

            entity.DeletedAtUtc.Should().BeNull();
            entity.DeletedBy.Should().BeNull();
            entity.DeletedVia.Should().BeNull();
        }

        [Fact]
        public void Updated_WithSpecifiedUserAndSystem_SetsAuditUpdatedProperties()
        {
            var entity = new SampleEntity();

            var user = "someone@example.com";
            var system = "some system";
            entity.Updated(user, system);

            entity.CreatedAtUtc.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
            entity.CreatedBy.Should().BeEquivalentTo(DefaultUser);
            entity.CreatedVia.Should().BeEquivalentTo(DefaultSystem);

            entity.LastUpdatedAtUtc!.Value.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
            entity.LastUpdatedBy.Should().BeEquivalentTo(user);
            entity.LastUpdatedVia.Should().BeEquivalentTo(system);

            entity.DeletedAtUtc.Should().BeNull();
            entity.DeletedBy.Should().BeNull();
            entity.DeletedVia.Should().BeNull();
        }

        [Fact]
        public void Deleted_WithSpecifiedUserAndSystem_SetsAuditDeletedProperties()
        {
            var entity = new SampleEntity();

            var user = "someone@example.com";
            var system = "some system";
            entity.Deleted(user, system);

            entity.CreatedAtUtc.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
            entity.CreatedBy.Should().BeEquivalentTo(DefaultUser);
            entity.CreatedVia.Should().BeEquivalentTo(DefaultSystem);

            entity.LastUpdatedAtUtc.Should().BeNull();
            entity.LastUpdatedBy.Should().BeNull();
            entity.LastUpdatedVia.Should().BeNull();

            entity.DeletedAtUtc!.Value.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
            entity.DeletedBy.Should().BeEquivalentTo(user);
            entity.DeletedVia.Should().BeEquivalentTo(system);
        }
    }
}