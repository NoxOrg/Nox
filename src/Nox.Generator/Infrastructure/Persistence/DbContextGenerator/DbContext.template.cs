// Generated

#nullable enable

using Nox;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Localization;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Diagnostics;
using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.PersistenceNameSpace}};

public partial class {{className}} : NoxDbContext
{
    public {{className}}(
            DbContextOptions<{{className}}> options,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider
        ) : base(noxSolution, databaseProvider, clientAssemblyProvider)
        {}

{{ for entity in solution.Domain.Entities }}
    public DbSet<{{entity.Name}}> {{entity.PluralName}} { get; set; } = null!;
{{ end }}

}