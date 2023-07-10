using System.Reflection;
using Nox.Secrets.Providers;

namespace Nox.Secrets.Tests;

public class UserSecretTests
{ 
      [Theory]
      [InlineData("SimpleSecret", "This is a simple secret")]
      [InlineData("NestedSecretSection.NestedSecret", "This is a nested secret")]
      [InlineData("NestedSecretSection.DeeperSecretSection.DeeperSecret", "This is a deeper secret")]
      public void Can_retrieve_a_secret(string key, string expectedResult)
      {
          //Arrange
          var provider = new UserSecretsProvider(Assembly.GetExecutingAssembly());
          var keys = new string[]
          {
              key
          };
          
          //Act
          var result = provider.GetSecrets(keys);
          //Assert
          Assert.NotNull(result);
          Assert.Single(result);
          Assert.Equal(expectedResult, result.First().Value);
      }
     
     
}