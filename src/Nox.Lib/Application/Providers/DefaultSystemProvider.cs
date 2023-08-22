using Nox.Abstractions;
using Nox.Types;

namespace Nox.Application.Providers;

public class DefaultSystemProvider : ISystemProvider
{
    public Text GetSystem() => Text.From("N/A");
}