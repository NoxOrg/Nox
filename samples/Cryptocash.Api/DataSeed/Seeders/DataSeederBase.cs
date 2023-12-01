using Nox.Domain;
using System.Data;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Infrastructure;

internal abstract class DataSeederBase<TModel, TEntity> : IDataSeeder
    where TEntity : class
{
    private readonly AppDbContext _dbContext;
    private readonly ISeedDataReader _seedDataReader;

    protected DataSeederBase(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
    {
        _dbContext = dbContext;
        _seedDataReader = seedDataReader;
    }

    public void Seed()
    {
        var dbSet = _dbContext.Set<TEntity>();

        if (dbSet.Any())
        {
            return;
        }

        var models = ReadModelsFromFile();
        var entities = models.Select(CreateEntityFromModel).ToList();

        dbSet.AddRange(entities);

        _dbContext.SaveChanges();
    }

    private IEnumerable<TModel> ReadModelsFromFile()
    {
        var filePath = Path.Combine("DataSeed", "Data", SourceFileName);
        return _seedDataReader.ReadFromFile<TModel>(filePath);
    }

    private TEntity CreateEntityFromModel(TModel model)
    {
        var entity = TransformToEntity(model);

        if (entity is AuditableEntityBase auditableEntity)
        {
            var user = "database.migration@noxorg.com";
            var system = "DatabaseMigration";

            auditableEntity.Created(user, system);
        }

        return entity;
    }

    protected static void SetIfNotNull(object? value, Action setPropertyAction)
    {
        if (value is not null)
        {
            setPropertyAction();
        }
    }

    protected abstract string SourceFileName { get; }

    protected abstract TEntity TransformToEntity(TModel model);
}