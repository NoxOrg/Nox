using System.Reflection;
using Nox.Secrets.Resolvers;

namespace Nox.Secrets.Tests;

public class UserSecretTests
{
    //These tests will only pass if you have secrets setup in local user secret store
    // [Theory]
    // [InlineData("SimpleSecret", "This is a simple secret")]
    // [InlineData("NestedSecretSection.NestedSecret", "This is a nested secret")]
    // [InlineData("NestedSecretSection.DeeperSecretSection.DeeperSecret", "This is a deeper secret")]
    // public void Can_retrieve_a_secret(string key, string expectedResult)
    // {
    //     //Arrange
    //     var resolver = new UserSecretResolver(Assembly.GetExecutingAssembly()!);
    //     var secrets = new Dictionary<string, string?>
    //     {
    //         { key, null }
    //     };
    //     //Act
    //     resolver.Resolve(secrets);
    //     //Assert
    //     Assert.NotNull(secrets);
    //     Assert.Single(secrets);
    //     Assert.Equal(expectedResult, secrets.First().Value);
    // }
    //
    // [Fact]
    // public async Task Calling_Async_GetSecrets_ThrowsException()
    // {
    //     var resolver = new UserSecretResolver(Assembly.GetExecutingAssembly()!);
    //     var exception = await Assert.ThrowsAsync<Exception>(async () => 
    //         await resolver.ResolveAsync(new Dictionary<string, string?>{{"dummy", null}})
    //     );
    //
    //     Assert.Equal("Synchronous 'Resolve' must be used for user secrets.", exception.Message);
    // }

}