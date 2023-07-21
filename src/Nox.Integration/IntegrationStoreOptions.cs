using System.Collections.Immutable;
using Nox.Integration.Abstractions;

namespace Nox.Integration;

public abstract class IntegrationStoreOptions: IIntegrationStoreOptions
{
    private readonly ImmutableSortedDictionary<Type, (IIntegrationStoreOptionsExtension Extension, int Ordinal)> _extensionsMap;
    
    public virtual bool IsFrozen { get; private set; }
    
    public virtual IEnumerable<IIntegrationStoreOptionsExtension> Extensions
        => _extensionsMap.Values.OrderBy(v => v.Ordinal).Select(v => v.Extension);

    protected IntegrationStoreOptions()
    {
        _extensionsMap = ImmutableSortedDictionary.Create<Type, (IIntegrationStoreOptionsExtension, int)>(NoxTypeFullNameComparer.Instance);
    }

    protected IntegrationStoreOptions(IReadOnlyDictionary<Type, IIntegrationStoreOptionsExtension> extensions)
    {
        _extensionsMap = ImmutableSortedDictionary.Create<Type, (IIntegrationStoreOptionsExtension, int)>(NoxTypeFullNameComparer.Instance)
            .AddRange(extensions.Select((p, i) => new KeyValuePair<Type, (IIntegrationStoreOptionsExtension, int)>(p.Key, (p.Value, i))));
    }
    
    protected IntegrationStoreOptions(ImmutableSortedDictionary<Type, (IIntegrationStoreOptionsExtension Extension, int Ordinal)> extensions)
    {
        _extensionsMap = extensions;
    }
    
    public virtual TExtension? FindExtension<TExtension>()
        where TExtension : class, IIntegrationStoreOptionsExtension
        => _extensionsMap.TryGetValue(typeof(TExtension), out var value) ? (TExtension)value.Extension : null;
    
    public virtual TExtension GetExtension<TExtension>()
        where TExtension : class, IIntegrationStoreOptionsExtension
    {
        var extension = FindExtension<TExtension>();
        if (extension == null)
        {
            throw new InvalidOperationException($"Integration store options extension {typeof(TExtension).Name} not found.");
        }

        return extension;
    }
    
    protected virtual ImmutableSortedDictionary<Type, (IIntegrationStoreOptionsExtension Extension, int Ordinal)> ExtensionsMap
        => _extensionsMap;
    
    public abstract Type ContextType { get; }
    
    public virtual void Freeze()
        => IsFrozen = true;
    
    public override bool Equals(object? obj)
        => ReferenceEquals(this, obj)
           || (obj is IntegrationStoreOptions otherOptions && Equals(otherOptions));

    protected virtual bool Equals(IntegrationStoreOptions other)
        => _extensionsMap.Count == other._extensionsMap.Count
           && _extensionsMap.Zip(other._extensionsMap)
               .All(
                   p => p.First.Value.Ordinal == p.Second.Value.Ordinal);
    
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        foreach (var (type, value) in _extensionsMap)
        {
            hashCode.Add(type);
        }

        return hashCode.ToHashCode();
    }

}