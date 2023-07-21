namespace Nox.Integration;

public sealed class NoxTypeFullNameComparer: IComparer<Type>, IEqualityComparer<Type>
{
    private NoxTypeFullNameComparer()
    {
    }

    public static readonly NoxTypeFullNameComparer Instance = new();
    
    public int Compare(Type? x, Type? y)
    {
        if (ReferenceEquals(x, y))
        {
            return 0;
        }

        if (x == null)
        {
            return -1;
        }

        if (y == null)
        {
            return 1;
        }

        return StringComparer.Ordinal.Compare(x.FullName, y.FullName);
    }
    
    public bool Equals(Type? x, Type? y)
        => Compare(x, y) == 0;
    
    public int GetHashCode(Type obj)
        => obj.Name.GetHashCode();
}