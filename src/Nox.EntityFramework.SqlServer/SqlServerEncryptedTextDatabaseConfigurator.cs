using Nox.Types;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.SqlServer;

public class SqlServerEncryptedTextDatabaseConfigurator : EncryptedTextDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType(EncryptedTextTypeOptions typeOptions)
    {
        return typeOptions.MaxLength == typeOptions.MinLength ? $"CHAR({typeOptions.MaxLength})" : $"VARCHAR({typeOptions.MaxLength})";
    }
}