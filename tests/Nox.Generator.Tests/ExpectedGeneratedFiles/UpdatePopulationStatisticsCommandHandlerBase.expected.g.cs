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
    protected readonly SampleWebAppDbContext _dbContext;
    
    /// <summary>
    /// Represents the Nox messenger.
    /// </summary>
    protected readonly INoxMessenger _messenger;
    
    public UpdatePopulationStatisticsCommandHandlerBase(
        SampleWebAppDbContext dbContext,
        INoxMessenger messenger
    )
    {
        _dbContext = dbContext;
        _messenger = messenger;
    }
    
    /// <summary>
    /// Executes UpdatePopulationStatistics.
    /// </summary>
    public abstract Task<INoxCommandResult> ExecuteAsync(UpdatePopulationStatistics command);
    
    /// <summary>
    /// Sends CountryUpdatedEvent.
    /// </summary>
    public async Task SendCountryUpdatedEventDomainEventAsync(CountryUpdatedEvent domainEvent)
    {
        await _messenger.SendMessageAsync(new string[] { "Mediator" }, domainEvent);
    }
}
