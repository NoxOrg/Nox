using FluentAssertions;
using Nox.Domain;
using Nox.Types;

namespace Nox.Lib.Tests.Domain
{
    public class AuditableEntityBaseTests
    {
        private class SampleEntity : AuditableEntityBase { }

        private static readonly User DefaultUser = User.From(System.Guid.Empty.ToString());
        private static readonly Text DefaultSystem = Text.From("N/A");

        private static readonly System.DateTime CurrentDateTimeUtc = System.DateTime.UtcNow;
        private static readonly TimeSpan DefaultDateTimePrecision = TimeSpan.FromMilliseconds(100);

        [Fact]
        public void Constructor_Default_ReturnsDefaultAuditCreatedProperties()
        {
            var entity = new SampleEntity();

            entity.CreatedAtUtc.Value.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
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

            var user = User.From("someone@example.com");
            var system = Text.From("some system");
            entity.Created(user, system);

            entity.CreatedAtUtc.Value.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
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

            var user = User.From("someone@example.com");
            var system = Text.From("some system");
            entity.Updated(user, system);

            entity.CreatedAtUtc.Value.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
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

            var user = User.From("someone@example.com");
            var system = Text.From("some system");
            entity.Deleted(user, system);

            entity.CreatedAtUtc.Value.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
            entity.CreatedBy.Should().BeEquivalentTo(DefaultUser);
            entity.CreatedVia.Should().BeEquivalentTo(DefaultSystem);

            entity.LastUpdatedAtUtc.Should().BeNull();
            entity.LastUpdatedBy.Should().BeNull();
            entity.LastUpdatedVia.Should().BeNull();

            entity.DeletedAtUtc!.Value.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
            entity.DeletedBy.Should().BeEquivalentTo(user);
            entity.DeletedVia.Should().BeEquivalentTo(system);
        }

        [Fact]
        public void Created_WithoutSpecifiedUserAndSystem_SetsAuditCreatedProperties()
        {
            var entity = new SampleEntity();

            entity.Created();

            entity.CreatedAtUtc.Value.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
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
        public void Updated_WithoutSpecifiedUserAndSystem_SetsAuditUpdatedProperties()
        {
            var entity = new SampleEntity();

            entity.Updated();

            entity.CreatedAtUtc.Value.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
            entity.CreatedBy.Should().BeEquivalentTo(DefaultUser);
            entity.CreatedVia.Should().BeEquivalentTo(DefaultSystem);

            entity.LastUpdatedAtUtc!.Value.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
            entity.LastUpdatedBy.Should().BeEquivalentTo(DefaultUser);
            entity.LastUpdatedVia.Should().BeEquivalentTo(DefaultSystem);

            entity.DeletedAtUtc.Should().BeNull();
            entity.DeletedBy.Should().BeNull();
            entity.DeletedVia.Should().BeNull();
        }

        [Fact]
        public void Deleted_WithoutSpecifiedUserAndSystem_SetsAuditDeletedProperties()
        {
            var entity = new SampleEntity();

            entity.Deleted();

            entity.CreatedAtUtc.Value.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
            entity.CreatedBy.Should().BeEquivalentTo(DefaultUser);
            entity.CreatedVia.Should().BeEquivalentTo(DefaultSystem);

            entity.LastUpdatedAtUtc.Should().BeNull();
            entity.LastUpdatedBy.Should().BeNull();
            entity.LastUpdatedVia.Should().BeNull();

            entity.DeletedAtUtc!.Value.Should().BeCloseTo(CurrentDateTimeUtc, DefaultDateTimePrecision);
            entity.DeletedBy.Should().BeEquivalentTo(DefaultUser);
            entity.DeletedVia.Should().BeEquivalentTo(DefaultSystem);
        }
    }
}