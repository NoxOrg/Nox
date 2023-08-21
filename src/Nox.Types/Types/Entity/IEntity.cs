using System;

namespace Nox.Types;

public interface IEntity
{
    string Type { get; }
    UInt32 Id { get; }
}