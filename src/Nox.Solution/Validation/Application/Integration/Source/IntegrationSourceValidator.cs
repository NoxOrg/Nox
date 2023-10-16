using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            //Data Connection required when adapter type != entity
            RuleFor(source => source!.DataConnectionName)
                .NotEmpty()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceDataConnectionEmpty, source!.Name, source!.DataConnectionName, integrationName))
                .Must(HaveValidDataConnection)
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceDataConnectionMissing, source!.Name, source!.DataConnectionName, integrationName))
                .When(source => source!.SourceAdapterType != IntegrationAdapterType.Entity);
            
            //Database options required when adapter type == Database
            RuleFor(source => source!.DatabaseOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceDatabaseOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceDatabaseOptionsValidator(integrationName))
                .When(source => source?.SourceAdapterType == IntegrationAdapterType.Database);

            //File options required when adapter type == File
            RuleFor(source => source!.FileOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceFileOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceFileOptionsValidator(integrationName))
                .When(source => source?.SourceAdapterType == IntegrationAdapterType.File);
            
            //Message queue options required when adapter type == MessageQueue
            RuleFor(source => source!.MessageQueueOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceMsgQueueOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceMessageQueueOptionsValidator(integrationName))
                .When(source => source?.SourceAdapterType == IntegrationAdapterType.MessageQueue);

            //WebApi options required when adapter type == WebApi
            RuleFor(source => source!.WebApiOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceHttpOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceHttpOptionsValidator(integrationName))
                .When(source => source?.SourceAdapterType == IntegrationAdapterType.WebApi);
        }

        private bool HaveValidDataConnection(string dataConnectionName)
        {
            return _dataConnections!.Any(dc => dc.Name == dataConnectionName);
        }
    }
}