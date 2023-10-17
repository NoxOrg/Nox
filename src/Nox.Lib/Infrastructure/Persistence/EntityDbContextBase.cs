using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using MediatR;

using Nox.Domain;
using Nox.Abstractions;
using Nox.Types;
using System.Net;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Nox.Types.EntityFramework.Types;

namespace Nox.Infrastructure.Persistence
{
    public abstract class EntityDbContextBase : DbContext
    {
        protected readonly IPublisher _publisher;
        protected readonly IUserProvider _userProvider;
        protected readonly ISystemProvider _systemProvider;


        protected EntityDbContextBase(
            IPublisher publisher,
            IUserProvider userProvider,
            ISystemProvider systemProvider,
            DbContextOptions options
            ) : base(options)
        {
            _publisher = publisher;
            _userProvider = userProvider;
            _systemProvider = systemProvider;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                HandleSystemFields();
                await HandleDomainEvents();
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Nox.Exceptions.ConcurrencyException($"Latest value of {nameof(IEntityConcurrent.Etag)} must be provided", HttpStatusCode.Conflict);
            }
        }
        protected virtual async Task HandleDomainEvents()
        {
            var entriesWithDomainEvents = GetEntriesWithDomainEvents();
            RaiseDomainEventsFor(entriesWithDomainEvents);
            await DispatchEvents(entriesWithDomainEvents.SelectMany(e => e.Entity.DomainEvents));
            ClearDomainEvents(entriesWithDomainEvents.ToList());
        }

        protected virtual void HandleSystemFields()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries<AuditableEntityBase>())
            {
                AuditEntity(entry);
            }

            foreach (var entry in ChangeTracker.Entries<IEntityConcurrent>())
            {
                TrackConcurrency(entry);
            }
        }

        protected virtual void AuditEntity(EntityEntry<AuditableEntityBase> entry)
        {
            var user = _userProvider.GetUser();
            var system = _systemProvider.GetSystem();

            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created(user, system);
                    break;

                case EntityState.Modified:
                    entry.Entity.Updated(user, system);
                    break;

                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.Deleted(user, system);
                    ReattachOwnedEntries<IOwnedEntity>(entry);
                    ReattachOwnedEntries<INoxType>(entry);
                    break;
            }
        }

        private void ReattachOwnedEntries<T>(EntityEntry<AuditableEntityBase> parentEntry)
            where T : class
        {
            foreach (var navigationEntry in parentEntry.Navigations)
            {
                foreach (var ownedEntry in ChangeTracker.Entries<T>())
                {
                    var isOwnedAndDeltetedEntry = ownedEntry.Metadata.IsOwned() && ownedEntry.State == EntityState.Deleted;
                    var isOwnedByCurrentParentEntry = ownedEntry.Entity == navigationEntry.CurrentValue || (navigationEntry.CurrentValue as IEnumerable<T>)?.Contains(ownedEntry.Entity) == true;

                    if (isOwnedAndDeltetedEntry && isOwnedByCurrentParentEntry)
                    {
                        ownedEntry.State = EntityState.Unchanged;
                    }
                }
            }
        }
        private void TrackConcurrency(EntityEntry<IEntityConcurrent> entry)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Property(e => e.Etag).CurrentValue = System.Guid.NewGuid();
                    break;

                case EntityState.Modified:
                case EntityState.Deleted:
                    entry.Property(e => e.Etag).OriginalValue = entry.Property(p => p.Etag).CurrentValue;
                    entry.Property(e => e.Etag).CurrentValue = System.Guid.NewGuid();
                    break;
            }
        }

        protected virtual EntityEntry<IEntityHaveDomainEvents>[] GetEntriesWithDomainEvents()
        {
            return ChangeTracker.Entries<IEntityHaveDomainEvents>().ToArray();
        }
        protected virtual void RaiseDomainEventsFor(IEnumerable<EntityEntry<IEntityHaveDomainEvents>> entriesWithDomainEvents)
        {
            foreach (var entry in entriesWithDomainEvents)
            {
                RaiseDomainEvent(entry);
            }
        }

        protected virtual void RaiseDomainEvent(EntityEntry<IEntityHaveDomainEvents> entry)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.RaiseCreateEvent();
                    break;

                case EntityState.Modified:
                    entry.Entity.RaiseUpdateEvent();
                    break;

                case EntityState.Deleted:
                    entry.Entity.RaiseDeleteEvent();
                    break;
            }
        }

        protected virtual async Task DispatchEvents(IEnumerable<IDomainEvent> selectMany)
        {
            var tasks = selectMany.Select(domainEvent => _publisher.Publish(domainEvent));
            await Task.WhenAll(tasks);
        }

        protected virtual void ClearDomainEvents(List<EntityEntry<IEntityHaveDomainEvents>> entriesWithDomainEvents)
        {
            entriesWithDomainEvents.ForEach(e => e.Entity.ClearDomainEvents());
        }

        /// <summary>
        /// Configure Entity Enumeration 
        /// </summary>
        protected virtual void ConfigureEnumeration(EntityTypeBuilder enumModelBuilder)
        {
            enumModelBuilder.HasKey(nameof(EnumTypeBase.Id));
            enumModelBuilder.Property(nameof(EnumTypeBase.Name)).IsRequired(true);
        }

        /// <summary>
        /// Configure Entity Enumeration Localization 
        /// </summary>
        protected virtual void ConfigureEnumerationLocalized(EntityTypeBuilder enumModelBuilder, Type enumType, Type enumLocalizedType)
        {
            enumModelBuilder.HasKey(nameof(EnumTypeLocalizedBase.Id), nameof(EnumTypeLocalizedBase.CultureCode));

            enumModelBuilder.Property(nameof(EnumTypeLocalizedBase.Name)).IsRequired(true);

            enumModelBuilder.Property(nameof(EnumTypeLocalizedBase.CultureCode))
                .IsUnicode(false)
                .IsFixedLength(false)
                .HasMaxLength(10)
                .HasConversion<CultureCodeConverter>();
            
            enumModelBuilder
                .HasOne(enumType)
                .WithMany()
                .HasForeignKey(nameof(EnumTypeLocalizedBase.Id));
        }
    }
}
