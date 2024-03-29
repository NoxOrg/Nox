using Microsoft.EntityFrameworkCore;
using Nox.Solution;

namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxIntegrationDatabaseProvider
{
    string ConnectionString { get; }
    DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer, string migrationsAssembly);
}