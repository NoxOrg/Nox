using System.Text.Json;
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

        var seedFile = Path.Combine(Directory.GetCurrentDirectory(),"SeedData","data",SourceFile);

        using var sr = new StreamReader(seedFile);
        var jsonText = sr.ReadToEnd();

        var modelData = JsonSerializer.Deserialize<IEnumerable<TModel>>(jsonText)!;
        var entities = TransformToEntities(modelData);

        dbSet.AddRange(entities);

        _dbContext.SaveChanges();
    }

    protected abstract string SourceFile { get; }

    protected abstract IEnumerable<TEntity> TransformToEntities(IEnumerable<TModel> models);
}