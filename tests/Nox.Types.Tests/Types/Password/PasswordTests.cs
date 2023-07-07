// ReSharper disable once CheckNamespace
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;

namespace Nox.Types.Tests.Types;

public class PasswordTests
{
    [Fact]
    public void Password_From_DefaultOptions()
    {
        var passwordText = "Test123.";
        var password = Password.From(passwordText);

        Assert.NotNull(password);
        Assert.NotEqual(passwordText, password.Value.HashText);
    }


    [Theory]
    [InlineData("Test123.")]
    [InlineData("!Password5.")]
    [InlineData("68922!dataP")]
    [InlineData("Correct.Password2.")]
    public void Password_From_DefaultOptions_NoSalting(string passwordText)
    {
        var password = Password.From(passwordText, new PasswordTypeOptions() { Salt = 0 });

        byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(passwordText);
        byte[] hash = SHA256.HashData(textBytes);
        var textHashedExpected = Convert.ToBase64String(hash);

        Assert.Equal(textHashedExpected, password.Value.HashText);
        Assert.Equal(string.Empty, password.Value.Salt);
    }


    [Theory]
    [InlineData("test123.")]
    [InlineData("!Password.")]
    [InlineData("68922dataP")]
    [InlineData("correct.password2.")]
    public void Password_From_DefaultOptions_ValidationFailed(string passwordText)
    {
        Assert.Throws<TypeValidationException>(() => _ =
            Password.From(passwordText)
        );
    }


    [Theory]
    [InlineData("Test123.")]
    [InlineData("!Password5.")]
    [InlineData("68922!dataP")]
    [InlineData("Correct.Password2.")]
    [InlineData("Testabc.")]
    [InlineData("!Password.")]
    [InlineData("datapassworD!dataP")]
    [InlineData("Correct.Password.")]
    public void Password_From_NumberNotMandatory_ValidationSuccess(string passwordText)
    {
        var password = Password.From(passwordText, new PasswordTypeOptions() { ForceNumber = false });

        Assert.NotNull(password);

    }
}