﻿using System.Linq.Dynamic.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Types;
using System.Linq.Expressions;
using System.Net;


namespace Nox.Infrastructure.Persistence
{
    /// <summary>
    /// Domain Entities DbContext
    /// </summary>
    public abstract class EntityDbContextBase : DbContext, IRepository
    {
        protected readonly IPublisher _publisher;
        protected readonly IUserProvider _userProvider;
        protected readonly ISystemProvider _systemProvider;
        protected readonly INoxDatabaseProvider _databaseProvider;
        protected readonly ILogger<EntityDbContextBase> _logger;

        protected EntityDbContextBase(
            IPublisher publisher,
            IUserProvider userProvider,
            ISystemProvider systemProvider,
            INoxDatabaseProvider databaseProvider,
            ILogger<EntityDbContextBase> logger,
            DbContextOptions options
            ) : base(options)
        {
            _publisher = publisher;
            _userProvider = userProvider;
            _systemProvider = systemProvider;
            _databaseProvider = databaseProvider;
            _logger = logger;
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
                throw new Exceptions.ConcurrencyException($"Latest value of {nameof(IEtag.Etag)} must be provided", HttpStatusCode.Conflict);
            }
        }

        public async ValueTask<T> AddEntityAsync<T>(T entity, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IEntity
        {
            var entry = await base.AddAsync(entity, cancellationToken);
            return entry.Entity;
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

            foreach (var entry in ChangeTracker.Entries<IEtag>())
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
            foreach (var navigationEntry in parentEntry.Navigations.Select(n => n.CurrentValue))
            {
                foreach (var ownedEntry in ChangeTracker.Entries<T>())
                {
                    var isOwnedAndDeltetedEntry = ownedEntry.Metadata.IsOwned() && ownedEntry.State == EntityState.Deleted;
                    var isOwnedByCurrentParentEntry = ownedEntry.Entity == navigationEntry || (navigationEntry as IEnumerable<T>)?.Contains(ownedEntry.Entity) == true;

                    if (isOwnedAndDeltetedEntry && isOwnedByCurrentParentEntry)
                    {
                        ownedEntry.State = EntityState.Unchanged;
                    }
                }
            }
        }
        private static void TrackConcurrency(EntityEntry<IEtag> entry)
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

        protected virtual async Task DispatchEvents(IEnumerable<IDomainEvent> domainEvents)
        {
            var tasks = domainEvents.Select(domainEvent =>
            {
                _logger.LogInformation("Publishing domain event '{Type}'", domainEvent.GetType());
                return _publisher.Publish(domainEvent);
            });
            await Task.WhenAll(tasks);
        }

        protected virtual void ClearDomainEvents(List<EntityEntry<IEntityHaveDomainEvents>> entriesWithDomainEvents)
        {
            entriesWithDomainEvents.ForEach(e => e.Entity.ClearDomainEvents());
        }

        /// <summary>
        /// Configure Entity Enumeration 
        /// </summary>
        protected virtual void ConfigureEnumeration(EntityTypeBuilder enumModelBuilder, EnumerationTypeOptions enumTypeOptions)
        {
            enumModelBuilder.HasKey(nameof(EnumerationBase.Id));

            enumModelBuilder
                .Property(nameof(EnumerationBase.Id))
                .HasConversion<EnumerationConverter>();

            enumModelBuilder
                .Property(nameof(EnumerationBase.Name))
                .IsRequired(true);

            foreach (var enumValue in enumTypeOptions.Values)
            {
                enumModelBuilder.HasData(new { Id = Enumeration.From(enumValue.Id, enumTypeOptions), Name = enumValue.Name });
            }
        }

        /// <summary>
        /// Configure Entity Enumeration Localization 
        /// </summary>
        protected virtual void ConfigureEnumerationLocalized(EntityTypeBuilder enumModelBuilder, Type enumType, Type enumLocalizedType, EnumerationTypeOptions enumTypeOptions, Culture defaultCultureCode)
        {
            enumModelBuilder.HasKey(nameof(EnumerationLocalizedBase.Id), nameof(EnumerationLocalizedBase.CultureCode));

            enumModelBuilder
                .Property(nameof(EnumerationLocalizedBase.Id))
                .HasConversion<EnumerationConverter>();

            enumModelBuilder.Property(nameof(EnumerationLocalizedBase.Name)).IsRequired(true);

            enumModelBuilder.Property(nameof(EnumerationLocalizedBase.CultureCode))
                .IsUnicode(false)
                .IsFixedLength(false)
                .HasMaxLength(10)
                .HasConversion<CultureCodeConverter>();

            enumModelBuilder
                .HasOne(enumType)
                .WithMany()
                .HasForeignKey(nameof(EnumerationLocalizedBase.Id));

            foreach (var enumValue in enumTypeOptions.Values)
            {
                enumModelBuilder.HasData(new { Id = Enumeration.From(enumValue.Id, enumTypeOptions), Name = enumValue.Name, CultureCode = Types.CultureCode.From(defaultCultureCode) });
            }
        }

        #region IRepository        

        IQueryable<T> IRepository.Query<T>(params Expression<Func<T, object>>[] includeExpressions) where T : class
        {
            IQueryable<T> query = Set<T>();
            if (includeExpressions is not null)
            {
                foreach (var includeExpression in includeExpressions)
                {
                    query = query.Include(includeExpression);
                }
            }
            return query;
        }

        ValueTask<T?> IRepository.FindAsync<T>(params object?[]? keyValues) where T : class
        {
            return Set<T>().FindAsync(keyValues);
        }
        ValueTask<T?> IRepository.FindAsync<T>(object?[]? keyValues, CancellationToken cancellationToken) where T : class
        {
            return Set<T>().FindAsync(keyValues, cancellationToken);
        }
        async ValueTask<T?> IRepository.FindAndIncludeAsync<T>(object?[]? keyValues, Expression<Func<T, IEnumerable<object>>> includeExpression, CancellationToken cancellationToken) where T : class
        {
            var entity = await Set<T>().FindAsync(keyValues, cancellationToken);
            if (entity is not null)
            {                
                await Entry(entity)
                    .Collection(includeExpression)
                    .LoadAsync(cancellationToken);
            }
            return entity;
        }

        async ValueTask<T?> IRepository.FindAndIncludeAsync<T, TProperty, TChildProperty>(object?[]? keyValues,
            Expression<Func<T, IEnumerable<TProperty>>> includeExpression,
            Expression<Func<TProperty, IEnumerable<TChildProperty>>> thenIncludeExpression, CancellationToken cancellationToken)
            where T : class
            where TProperty : class
            where TChildProperty : class
        {
            var entity = await Set<T>().FindAsync(keyValues, cancellationToken);
            if (entity is not null)
            {                
                await Entry(entity)
                    .Collection(includeExpression)
                    .Query().Include(thenIncludeExpression)
                    .LoadAsync(cancellationToken);
            }
            return entity;
        }
    
        async ValueTask<T?> IRepository.FindAndIncludeAsync<T>(object?[]? keyValues, Expression<Func<T, object?>> includeExpression, CancellationToken cancellationToken) where T : class
        {
            var entity = await Set<T>().FindAsync(keyValues, cancellationToken);
            if (entity is not null)
            {
                await Entry(entity).Reference(includeExpression).LoadAsync(cancellationToken);
            }
            return entity;
        }
        
        async ValueTask<T?> IRepository.FindAndIncludeAsync<T, TProperty, TChildProperty>(object?[]? keyValues,
            Expression<Func<T, TProperty?>> includeExpression,
            Expression<Func<TProperty, IEnumerable<TChildProperty>>> thenIncludeExpression, CancellationToken cancellationToken)
            where T : class
            where TProperty : class
            where TChildProperty : class
        {
            var entity = await Set<T>().FindAsync(keyValues, cancellationToken);
            if (entity is not null)
            {                
                await Entry(entity).Reference(includeExpression)
                    .Query().Include(thenIncludeExpression)
                    .LoadAsync(cancellationToken);
            }
            return entity;
        }
        async ValueTask<T> IRepository.AddAsync<T>(T entity, CancellationToken cancellationToken)
        {
            var entry = await AddAsync(entity, cancellationToken);
            return entry.Entity;
        }

        void IRepository.Update<T>(T entity)
        {
            Update(entity);
        }

        public void Delete<T>(T entity) where T : IEntity
        {
            Remove(entity);
        }
        public void DeleteRange<T>(IEnumerable<T> entities) where T : IEntity
        {
            RemoveRange((IEnumerable<object>)entities);
        }

        public void DeleteOwned<T>(T entity) where T : IOwnedEntity
        {
            Remove(entity);
        }

        public void DeleteOwned<T>(IEnumerable<T> entities) where T : IOwnedEntity
        {
            ArgumentNullException.ThrowIfNull(entities);

            entities.ForEach(e => DeleteOwned(e));
        }
        public virtual async Task<long> GetSequenceNextValueAsync(string sequenceName)
        {
            var connection = base.Database.GetDbConnection();
            try
            {
                await connection.OpenAsync();
                using var cmd = connection.CreateCommand();
                cmd.CommandText = _databaseProvider.GetSqlStatementForSequenceNextValue(sequenceName);
                var result = await cmd.ExecuteScalarAsync();
                return (long)result!;
            }
            finally
            {
                await connection.CloseAsync();
            }
        }
        Task IRepository.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return SaveChangesAsync(cancellationToken);
        }

        public void SetStateDetached(object entity)
        {
            Entry(entity).State = EntityState.Detached;
        }        
        #endregion
    }
}
