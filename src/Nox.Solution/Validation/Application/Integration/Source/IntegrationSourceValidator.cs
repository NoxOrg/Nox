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

            RuleFor(source => source!.DataConnectionName)
                .NotEmpty()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceDataConnectionEmpty, source!.Name, source!.DataConnectionName, integrationName))
                .Must(HaveValidDataConnection)
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceDataConnectionMissing, source!.Name, source!.DataConnectionName, integrationName));

            RuleFor(source => source!.Schedule!)
                .SetValidator(source => new IntegrationScheduleValidator(source!.Name, integrationName));
            
            RuleFor(source => source!.DatabaseOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceDatabaseOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceDatabaseOptionsValidator(integrationName))
                .When(source => source?.SourceAdapterType == IntegrationAdapterType.Database);

            RuleFor(source => source!.FileOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceFileOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceFileOptionsValidator(integrationName))
                .When(source => source?.SourceAdapterType == IntegrationAdapterType.File);
            
            RuleFor(source => source!.MessageQueueOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceMsgQueueOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceMessageQueueOptionsValidator(integrationName))
                .When(source => source?.SourceAdapterType == IntegrationAdapterType.MessageQueue);

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