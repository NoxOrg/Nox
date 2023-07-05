using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework;
public class ValueObjectConverter<TValueObject,T> : ValueConverter<TValueObject, T>
    where TValueObject : ValueObject<T, TValueObject>, new()
{
    public ValueObjectConverter() : base(v => v.Value, v => new TValueObject().FromDatabase(v) ) { }
}