using Nox.Types;

namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxFileReceiveAdapter: INoxReceiveAdapter
{
    List<NoxSimpleTypeDefinition> Attributes { get; }
}