using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation
{
    internal class IntegrationTargetValidator: AbstractValidator<IntegrationTarget>
    {
        private readonly IEnumerable<DataConnection>? _dataConnections;
        public IntegrationTargetValidator(string integrationName, IEnumerable<DataConnection>? dataConnections)
        {
            _dataConnections = dataConnections;

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.IntegrationTargetNameEmpty, integrationName));

            RuleFor(p => p.TargetAdapterType)
                .IsInEnum()
                .WithMessage(p => string.Format(ValidationResources.IntegrationTargetTypeEmpty, p.Name, integrationName, IntegrationTargetAdapterType.File.ToNameList()));
            
            //Data Connection required when adapter type != entity
            RuleFor(p => p.DataConnectionName)
                .NotEmpty()
                .WithMessage(source => string.Format(ValidationResources.IntegrationTargetDataConnectionEmpty, source!.Name, source!.DataConnectionName, integrationName))
                .Must(HaveValidDataConnection)
                .WithMessage(m => string.Format(ValidationResources.IntegrationTargetDataConnectionMissing, m.Name, integrationName, m.DataConnectionName));

            //Database options required when adapter type == Table || type == StoredProcedure
            RuleFor(target => target!.DatabaseOptions)
                .NotNull()
                .WithMessage(target => string.Format(ValidationResources.IntegrationTargetTableOptionsEmpty, target!.Name, integrationName))
                .SetValidator(target => new IntegrationTargetDatabaseOptionsValidator(integrationName, target.TargetAdapterType))
                .When(target => target?.TargetAdapterType is IntegrationTargetAdapterType.DatabaseTable or IntegrationTargetAdapterType.StoredProcedure);
            
            //File options required when adapter type == File
            RuleFor(target => target!.FileOptions)
                .NotNull()
                .WithMessage(target => string.Format(ValidationResources.IntegrationTargetFileOptionsEmpty, target!.Name, integrationName))
                .SetValidator(target => new IntegrationTargetFileOptionsValidator(integrationName))
                .When(target => target?.TargetAdapterType == IntegrationTargetAdapterType.File);
            
            //Message queue options required when adapter type == MessageQueue
            RuleFor(target => target!.MessageQueueOptions)
                .NotNull()
                .WithMessage(target => string.Format(ValidationResources.IntegrationTargetMsgQueueOptionsEmpty, target!.Name, integrationName))
                .SetValidator(target => new IntegrationTargetMessageQueueOptionsValidator(integrationName))
                .When(target => target?.TargetAdapterType == IntegrationTargetAdapterType.MessageQueue);

            //WebApi options required when adapter type == WebApi
            RuleFor(target => target!.WebApiOptions)
                .NotNull()
                .WithMessage(target => string.Format(ValidationResources.IntegrationTargetHttpOptionsEmpty, target!.Name, integrationName))
                .SetValidator(target => new IntegrationTargetHttpOptionsValidator(integrationName))
                .When(target => target?.TargetAdapterType == IntegrationTargetAdapterType.WebApi);
            
        }
        
        private bool HaveValidDataConnection(string? dataConnectionName)
        {
            if (!string.IsNullOrWhiteSpace(dataConnectionName))
            {
                return _dataConnections!.Any(dc => dc.Name == dataConnectionName);    
            }

            return true;
        }
    }
}