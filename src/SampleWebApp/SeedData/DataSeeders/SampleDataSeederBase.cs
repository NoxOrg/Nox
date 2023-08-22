using System.Text.Json;
using Nox.Domain;
using Nox.Types;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.SeedData;

internal abstract class SampleDataSeederBase<TModel, TEntity> : INoxDataSeeder
    where TEntity : class
{
    private readonly SampleWebAppDbContext _dbContext;

    protected SampleDataSeederBase(SampleWebAppDbContext dbContext)
    {
        _dbContext = dbContext;
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
        using var reader = new StreamReader(Path.Combine("SeedData/data/", SourceFile));
        var json = reader.ReadToEnd();

        return JsonSerializer.Deserialize<IEnumerable<TModel>>(json)!;
    }

    private TEntity CreateEntityFromModel(TModel model)
    {
        var entity = TransformToEntity(model);

        if (entity is AuditableEntityBase auditableEntity)
        {
            var user = User.From("database.migration@noxorg.com");
            var system = Text.From("DatabaseMigration");

            auditableEntity.Created(user, system);
        }

        return entity;
    }

    protected abstract string SourceFile { get; }

    protected abstract TEntity TransformToEntity(TModel models);
}