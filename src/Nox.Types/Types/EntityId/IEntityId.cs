using System;

namespace Nox.Types;

public interface IEntityId
{
    string Type { get; }
    UInt32 Id { get; }
}
public interface IWritableEntityId
{
    string Type { set; }
    UInt32 Id { set; }
}