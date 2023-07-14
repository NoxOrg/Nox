using Nox.IntegrationSource.File;
using Nox.Solution;

namespace Nox.IntegrationSource.Tests;

public class CsvFileSourceTests
{
    [Fact]
    public void Can_create_a_CSV_File_Source_from_definition()
    {
        var config = new Solution.IntegrationSource
        {
            Name = "TestCsvSource",
            Description = "Test CSV source description",
            FileOptions = new IntegrationSourceFileOptions
            {
                Filename = "test_file.csv"
            }
        };

        var dataConnection = new DataConnection
        {
            Name = "TestCsvConnection",
            Provider = DataConnectionProvider.CsvFile,
            ServerUri = "../files"
        };

        var source = new CsvIntegrationSource(config, dataConnection);
        var dfSource = source.DataFlowSource();
        
    }
}