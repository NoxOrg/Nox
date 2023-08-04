// Generated

#nullable enable

using Nox;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Localization;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Diagnostics;
using SampleWebApp.Domain;

namespace SampleWebApp.Infrastructure.Persistence;

public partial class SampleWebAppDbContext : NoxDbContext
{
    public SampleWebAppDbContext(
            DbContextOptions<SampleWebAppDbContext> options,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider
        ) : base(noxSolution, databaseProvider, clientAssemblyProvider)
        {}


    public DbSet<Country> Countries { get; set; } = null!;

    public DbSet<Currency> Currencies { get; set; } = null!;

    public DbSet<Store> Stores { get; set; } = null!;

    public DbSet<CountryLocalNames> CountryLocalNames { get; set; } = null!;


}