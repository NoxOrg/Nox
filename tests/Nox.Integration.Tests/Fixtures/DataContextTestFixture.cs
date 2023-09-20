//using System.Reflection;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Nox.Application.Providers;
//using Nox.EntityFramework.SqlServer;
//using Nox.Solution;
//using Nox.Types.EntityFramework.Abstractions;
//using TestWebApp.Infrastructure.Persistence;

//namespace Nox.Integration.Tests.Fixtures
//{
//    public class DataContextTestFixture
//    {
//        private const string _solutionFileAsEmbeddedResourceName = @"Nox.Integration.Tests.DatabaseIntegrationTests.Design.test.solution.nox.yaml";

//        public DataContextTestFixture()
//        {
//            ServiceCollection services = new();
//            services.AddNoxLib(Assembly.GetExecutingAssembly());

//            using var serviceProvider = services.BuildServiceProvider();

//            var solutionFileDictionary = new Dictionary<string, Func<TextReader>>
//            {
//                [_solutionFileAsEmbeddedResourceName] = () =>
//                {
//                    var assembly = Assembly.GetExecutingAssembly();
//                    using (Stream stream = assembly.GetManifestResourceStream(_solutionFileAsEmbeddedResourceName)!)
//                    using (StreamReader reader = new StreamReader(stream!))
//                    {
//                        string result = reader.ReadToEnd();
//                        return new StringReader(result);
//                    }
//                }
//            };

//            var databaseConfigurator = new SqlServerDatabaseProvider(serviceProvider.GetServices<INoxTypeDatabaseConfigurator>());
//            var solution = new NoxSolutionBuilder()
//                .UseYamlFilesAndContent(solutionFileDictionary)
//                .Build();

//            var options = new DbContextOptionsBuilder<TestWebAppDbContext>()
//                .UseInMemoryDatabase("Nox")
//                .Options;

//            DbContext = new TestWebAppDbContext(
//                options,
//                solution,
//                databaseConfigurator,
//                new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()),
//                new DefaultUserProvider(),
//                new DefaultSystemProvider());
//        }

//        public TestWebAppDbContext DbContext { get; }
//    }
//}