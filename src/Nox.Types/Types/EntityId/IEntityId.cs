using System;

namespace Nox.Types;

public interface IEntityId
{
    string Type { get; }
    UInt32 Id { get; }
}