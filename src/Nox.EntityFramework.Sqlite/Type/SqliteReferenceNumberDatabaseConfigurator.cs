using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.Configurations;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.Sqlite.Type;

public class SqliteReferenceNumberDatabaseConfigurator : ReferenceNumberDatabaseConfigurator, ISqliteNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    protected override void CreateSequence(NoxCodeGenConventions noxSolutionCodeGeneratorState, NoxTypeDatabaseConfiguration property, Entity entity, ModelBuilder modelBuilder, ReferenceNumberTypeOptions typeOptions)
    {
        //SQL Lite does not support sequences
    }
}