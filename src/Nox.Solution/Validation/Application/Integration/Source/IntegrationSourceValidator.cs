using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class IntegrationSourceValidator: AbstractValidator<IntegrationSource?>
    {
        private readonly IEnumerable<DataConnection>? _dataConnections;
        
        public IntegrationSourceValidator(string integrationName, IEnumerable<DataConnection>? dataConnections, string dataConnectionName)
        {
            _dataConnections = dataConnections;

            RuleFor(source => source!.Name)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.IntegrationSourceNameEmpty, integrationName));

            RuleFor(source => source!.DataConnectionName)
                .NotEmpty()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceDataConnectionEmpty, source!.Name, integrationName))
                .Must(HaveValidDataConnection)
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceDataConnectionMissing, source!.Name, integrationName));

            RuleFor(source => source!.Schedule!)
                .SetValidator(source => new IntegrationScheduleValidator(source!.Name, integrationName));
            
            var dataConnection = _dataConnections!.First(dc => dc.Name.Equals(dataConnectionName));

            RuleFor(source => source!.DatabaseOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceDatabaseOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceDatabaseOptionsValidator(integrationName))
                .When(_ => dataConnection.Provider is DataConnectionProvider.Postgres or DataConnectionProvider.MySql or DataConnectionProvider.SqLite or DataConnectionProvider.SqlServer);

            RuleFor(source => source!.FileOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceFileOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceFileOptionsValidator(integrationName))
                .When(_ => dataConnection.Provider is DataConnectionProvider.CsvFile or DataConnectionProvider.ExcelFile or DataConnectionProvider.JsonFile or DataConnectionProvider.ParquetFile or DataConnectionProvider.XmlFile);
            
            RuleFor(source => source!.MessageQueueOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceMsgQueueOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceMessageQueueOptionsValidator(integrationName))
                .When(_ => dataConnection.Provider is DataConnectionProvider.AmazonSqs or DataConnectionProvider.RabbitMq or DataConnectionProvider.AzureServiceBus);
            
            RuleFor(source => source!.WebApiOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceHttpOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceHttpOptionsValidator(integrationName))
                .When(_ => dataConnection.Provider is DataConnectionProvider.WebApi);
            
        }
        
        private bool HaveValidDataConnection(string dataConnectionName)
        {
            return _dataConnections!.Any(dc => dc.Name == dataConnectionName);
        }
    }
}