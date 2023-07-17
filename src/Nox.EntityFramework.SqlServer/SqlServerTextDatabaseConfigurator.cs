using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Nox.Types;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.SqlServer;

public class SqlServerTextDatabaseConfigurator : TextDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType(TextTypeOptions typeOptions)
    {
        // see also https://www.educative.io/answers/what-is-the-difference-between-varchar-and-nvarchar
        if (typeOptions.IsUnicode)
        {
            return typeOptions.MaxLength == typeOptions.MinLength ? $"NCHAR({typeOptions.MaxLength})" : $"NVARCHAR({typeOptions.MaxLength})";
        }

        return typeOptions.MaxLength == typeOptions.MinLength ? $"CHAR({typeOptions.MaxLength})" : $"VARCHAR({typeOptions.MaxLength})";
    }
}