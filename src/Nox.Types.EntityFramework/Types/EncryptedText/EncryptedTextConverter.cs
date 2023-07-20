using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class EncryptedTextConverter : ValueConverter<EncryptedText, byte[]>
{
    public EncryptedTextConverter() : base(encryptedText => encryptedText.Value, encryptedBase64 => EncryptedText.FromEncryptedString(encryptedBase64)) { }
}