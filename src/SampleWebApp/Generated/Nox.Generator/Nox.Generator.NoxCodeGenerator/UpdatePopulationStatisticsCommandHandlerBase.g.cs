// Generated

#nullable enable

using Nox.Types;
using System.Collections.Generic;
using Nox.Abstractions;
using SampleWebApp.Domain;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application;

/// <summary>
/// Instructs the service to collect updated population statistics.
/// </summary>
public abstract partial class UpdatePopulationStatisticsCommandHandlerBase
{
    
    
    /// <summary>
    /// Represents the DB context.
    /// </summary>
    protected SampleWebAppDbContext DbContext { get; set; } = null!;
    
    
    /// <summary>
    /// Represents the Nox messenger.
    /// </summary>
    protected INoxMessenger Messenger { get; set; } = null!;
    
    public UpdatePopulationStatisticsCommandHandlerBase(
        SampleWebAppDbContext dbContext,
        INoxMessenger messenger
    )
    {
        DbContext = dbContext;
        Messenger = messenger;
    }
    
    public abstract Task<INoxCommandResult> ExecuteAsync(UpdatePopulationStatistics command);
    
    public async Task SendCountryNameUpdatedEventDomainEventAsync(CountryNameUpdatedEvent domainEvent)
    {
        await Messenger.SendMessageAsync(new string[] { "Mediator" }, domainEvent);
    }
}
