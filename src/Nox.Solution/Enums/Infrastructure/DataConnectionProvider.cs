using System;
using System.Linq;

namespace Nox
{
    public enum DataConnectionProvider
    {
        AmazonSqs,
        AzureServiceBus,
        CsvFile,
        ExcelFile,
        JsonFile,
        MySql,
        ParquetFile,
        Postgres,
        RabbitMq,
        SqLite,
        SqlServer,
        WebApi,
        XmlFile,
        InMemory
    }
}