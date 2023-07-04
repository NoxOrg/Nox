using Moq;
using Nox.Solution.Macros;
using Nox.Solution.Utils;

namespace Nox.Solution.Tests.Macros;

public class EnvironmentVariableMacroParserTest
{

    [Fact]
    public void When_Parsing_Macros_Should_Replace_EnvironmentVariables()
    {
        var environmentProvider = new Mock<IEnvironmentProvider>();
        environmentProvider.Setup(service => service.GetEnvironmentVariable("CACHE_USER")).Returns("cacheuser1");
        environmentProvider.Setup(service => service.GetEnvironmentVariable("CACHE_PASSWORD")).Returns("cachepwd1");
        environmentProvider.Setup(service => service.GetEnvironmentVariable("DB_PASSWORD")).Returns(@"#{}$%@'\\");
        environmentProvider.Setup(service => service.GetEnvironmentVariable("DB_USER")).Returns("dbuser1");
        environmentProvider.Setup(service => service.GetEnvironmentVariable("SECRETS_USER")).Returns("secretuser1");
        environmentProvider.Setup(service => service.GetEnvironmentVariable("SECRETS_PASSWORD")).Returns("secretpwd1");


        var noxConfig = new NoxSolutionBuilder()
            .UseYamlFile("./files/macros/sample.solution.nox.yaml")
            .UseEnvironmentMacroParser(new EnvironmentVariableMacroParser(environmentProvider.Object))
            .Build();

        Assert.NotNull(noxConfig);

        Assert.Equal("cacheuser1",noxConfig.Infrastructure?.Persistence.CacheServer?.User);
        Assert.Equal("cachepwd1",noxConfig.Infrastructure?.Persistence.CacheServer?.Password);
        Assert.Equal("dbuser1",noxConfig.Infrastructure?.Persistence.DatabaseServer?.User);
        Assert.Equal(@"#{}$%@'\\",noxConfig.Infrastructure?.Persistence.DatabaseServer?.Password);
        Assert.Equal("secretuser1",noxConfig.Infrastructure?.Security?.Secrets?.SecretsServer?.User);
        Assert.Equal("secretpwd1",noxConfig.Infrastructure?.Security?.Secrets?.SecretsServer?.Password);

    }

    [Fact]
    public void When_Creating_NoxSolution_Uses_System_Environment_By_Default()
    {
        try
        {
            System.Environment.SetEnvironmentVariable("MyTemp","MyTemp");
            System.Environment.SetEnvironmentVariable("MyTempDir","MyTempDir");

            var noxConfig = new NoxSolutionBuilder()
                .UseYamlFile("./files/macros/envvar.solution.nox.yaml")
                .Build();

            Assert.NotNull(noxConfig);

            Assert.Equal("EnvTestService", noxConfig.Name);
            Assert.NotEqual("${{ env.MyTemp }} ${{ env.MyTempDir }}", noxConfig.Description);
        }
        finally
        {
            System.Environment.SetEnvironmentVariable("MyTemp",null);
            System.Environment.SetEnvironmentVariable("MyTempDir",null);
        }


    }

}