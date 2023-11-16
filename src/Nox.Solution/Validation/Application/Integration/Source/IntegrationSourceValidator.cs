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

            //Database options required when adapter type == DatabaseQuery
            RuleFor(source => source!.QueryOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceDatabaseOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceQueryOptionsValidator(integrationName))
                .When(source => source?.SourceAdapterType == IntegrationSourceAdapterType.DatabaseQuery);

            //File options required when adapter type == File
            RuleFor(source => source!.FileOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceFileOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceFileOptionsValidator(integrationName))
                .When(source => source?.SourceAdapterType == IntegrationSourceAdapterType.File);
            
            //Message queue options required when adapter type == MessageQueue
            RuleFor(source => source!.MessageQueueOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceMsgQueueOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceMessageQueueOptionsValidator(integrationName))
                .When(source => source?.SourceAdapterType == IntegrationSourceAdapterType.MessageQueue);

            //WebApi options required when adapter type == WebApi
            RuleFor(source => source!.WebApiOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceHttpOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceHttpOptionsValidator(integrationName))
                .When(source => source?.SourceAdapterType == IntegrationSourceAdapterType.WebApi);
        }

        private bool HaveValidDataConnection(string dataConnectionName)
        {
            return _dataConnections!.Any(dc => dc.Name == dataConnectionName);
        }
    }
}