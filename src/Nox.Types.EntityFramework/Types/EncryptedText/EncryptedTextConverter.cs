using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class EncryptedTextConverter : ValueConverter<EncryptedText, byte[]>
{
    public EncryptedTextConverter() : base(encryptedText => encryptedText.Value, encryptedBase64 => ValueObject<byte[], EncryptedText>.FromDatabase(encryptedBase64)) { }
}