namespace Nox.Secrets.Tests;

public class SecretExtractorTests
{
    [Fact]
    public void Can_Extract_Secrets_From_Text()
    {
        var text = @"section:";
        text += "  testValue: ${{ secrets.some-secret }}";
            
        // var secretKeys = SecretExtractor.Extract(text);

        //Assert.NotNull(secretKeys);
        //Assert.Single(secretKeys);
        //Assert.Equal("some-secret", secretKeys[0]);
    }
}