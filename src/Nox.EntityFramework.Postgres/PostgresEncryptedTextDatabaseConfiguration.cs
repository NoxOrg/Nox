using Nox.Types;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.Postgres;

public class PostgresEncryptedTextDatabaseConfiguration : EncryptedTextDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override string? GetColumnType(EncryptedTextTypeOptions typeOptions)
    {
        return typeOptions.MaxLength == typeOptions.MinLength ? $"CHAR({typeOptions.MaxLength})" : $"VARCHAR({typeOptions.MaxLength})";
    }
}