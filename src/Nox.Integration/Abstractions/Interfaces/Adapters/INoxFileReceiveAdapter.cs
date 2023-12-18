using Nox.Types;

namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxFileReceiveAdapter: INoxReceiveAdapter
{
    IReadOnlyList<NoxSimpleTypeDefinition> Attributes { get; }
}