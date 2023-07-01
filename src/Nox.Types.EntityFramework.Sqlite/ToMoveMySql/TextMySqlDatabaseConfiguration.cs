using Nox.Types.EntityFramework.Sqlite.ToMoveEF;

namespace Nox.Types.EntityFramework.Sqlite.ToMoveMySql;


/// <summary>
/// This will move to Nox.Types.EntityFramework.MySQL, Overriden implementation for Text
/// </summary>
public class TextMySqlDatabaseConfiguration : TextDatabaseConfiguration
{
    public override string? GetColumnType(TextTypeOptions typeOptions)
    {
        return $"VARCHAR({typeOptions.MaxLength})";
    }
}