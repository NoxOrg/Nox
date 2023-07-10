using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nox.Secrets.Abstractions;
using Nox.Solution;

namespace Nox.Secrets.Tests;

////These tests can only be run if you have access to the Azure nox-EDA1DB500EBCEB02, we-key-nox-test key vaults with your azure login
public class ResolverTests: IClassFixture<SecretsFixture>
{
    private readonly SecretsFixture _fixture;

    public ResolverTests(SecretsFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Fact]
    public void Result_Must_be_empty_if_secret_does_not_exist()
    {
        var resolver = _fixture.ServiceProvider.GetRequiredService<ISecretsResolver>();
        resolver.ConfigureForTest();
        
        var keys = new string[]
        {
            "non-existing-secret"
        };
       
        var result = resolver.Resolve(keys);
        Assert.Empty(result);
    }
    
    //Secrets are resolved in this order: organization, solution, user. 
    [Theory]
    [InlineData("org-only-secret", "This is an organization only secret")]
    [InlineData("sln-only-secret", "This is a solution only secret")]
    [InlineData("user-secret", "This secret only exists in user secrets")]
    [InlineData("org-sln-secret", "This is a secret that exists in org and sln and this is the solution value")]
    [InlineData("org-sln-user-secret", "This is a secret that exists in org, sln and user and this is the user value")]
    public void Must_honor_the_order_or_precedence(string key, string expectedValue)
    {
        var resolver = _fixture.ServiceProvider.GetRequiredService<ISecretsResolver>();
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