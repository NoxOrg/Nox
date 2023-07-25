using Microsoft.Extensions.DependencyInjection;
using Nox.Secrets.Abstractions;

namespace Nox.Secrets.Tests;

public class ResolverTests: IClassFixture<SecretsFixture>
{
    private readonly SecretsFixture _fixture;

    public ResolverTests(SecretsFixture fixture)
    {
        _fixture = fixture;
    }
    
#if DEBUG
    [Fact]
#else
    [Fact (Skip = "Only available if you have started the hashicorp vault docker container")]
#endif  
    public void Result_Must_be_empty_if_secret_does_not_exist()
    {
        var resolver = _fixture.ServiceProvider.GetRequiredService<INoxSecretsResolver>();
        resolver.ConfigureForTest();
        
        var keys = new string[]
        {
            "non-existing-secret"
        };
       
        var result = resolver.Resolve(keys);
        Assert.Empty(result);
    }
    
#if DEBUG
    [Theory]
    [InlineData("org-only-secret", "This is an organization only secret")]
    [InlineData("sln-only-secret", "This is a solution only secret")]
    [InlineData("user-secret", "This secret only exists in user secrets")]
    [InlineData("org-sln-secret", "This is a secret that exists in org and sln and this is the solution value")]
    [InlineData("org-sln-user-secret", "This is a secret that exists in org, sln and user and this is the user value")]
#else
    [Theory (Skip = "Only available if you have started the hashicorp vault docker container")]
#endif      
    public void Must_honor_the_order_or_precedence(string key, string expectedValue)
    {
        var resolver = _fixture.ServiceProvider.GetRequiredService<INoxSecretsResolver>();
        resolver.ConfigureForTest();
        
        var keys = new string[]
        {
            key
        };
       
        var result = resolver.Resolve(keys);
        Assert.Single(result);
        Assert.Equal(expectedValue, result[key]);
    }
}