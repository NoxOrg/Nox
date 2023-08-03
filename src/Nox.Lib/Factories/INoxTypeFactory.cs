using Nox.Domain;
using Nox.Types;
using Nox.Extensions;

namespace Nox.Factories
{

    /// <summary>
    /// Factory for Entity created by using a dto
    /// </summary>    
    public interface INoxTypeFactory<T> where T : INoxType
    {
        T? CreateNoxType(Solution.Entity entityDefinition, string propertyName, dynamic? value);
    }
}
