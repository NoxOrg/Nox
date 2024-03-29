using System.Reflection;

namespace Nox.Secrets.Tests;

public class UserSecretTests
{ 
      [Theory (Skip = "This test can only be run if you have configured user secrets")]
      [InlineData("SimpleSecret", "This is a simple secret")]
      [InlineData("NestedSecretSection.NestedSecret", "This is a nested secret")]
      [InlineData("NestedSecretSection.DeeperSecretSection.DeeperSecret", "This is a deeper secret")]
      public void Can_retrieve_a_secret(string key, string expectedResult)
      {
          //Arrange
          var resolver = new UserSecretsResolver(Assembly.GetExecutingAssembly());
          var keys = new string[]
          {
              key
          };
          
          //Act
          var result = resolver.Resolve(keys);
          //Assert
          Assert.NotNull(result);
          Assert.Single(result);
          Assert.Equal(expectedResult, result.First().Value);
      }
     
     
}