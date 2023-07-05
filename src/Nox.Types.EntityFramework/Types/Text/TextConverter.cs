using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;
public class TextConverter : ValueConverter<Text, string>
{
    public TextConverter() : base(text => text.Value, textValue => Text.From(textValue)) { }
}