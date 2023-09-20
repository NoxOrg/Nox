using Microsoft.EntityFrameworkCore;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.Fixtures;

public interface INoxTestContainer
{
    DbContextOptions<TestWebAppDbContext> CreateDbOptions();
}
