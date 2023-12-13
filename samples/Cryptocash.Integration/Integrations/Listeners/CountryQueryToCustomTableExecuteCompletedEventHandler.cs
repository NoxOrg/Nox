using CryptocashIntegration.Application.Integrations;
using MediatR;
using Nox.Integration.Abstractions.Models;

namespace Cryptocash.Integration.Integrations;

public class CountryQueryToCustomTableExecuteCompletedEventHandler: INotificationHandler<CountryQueryToCustomTableExecuteCompletedEvent>
{
    private readonly ILogger _logger;

    public CountryQueryToCustomTableExecuteCompletedEventHandler(ILogger<CountryQueryToCustomTableExecuteCompletedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(CountryQueryToCustomTableExecuteCompletedEvent notification, CancellationToken cancellationToken)
    {
        var payload = (EtlExecuteCompletedDto)notification.Dto!;
        _logger.LogInformation("Received: {0}\n " +
                               "Payload\n" +
                               "------------------------------\n" +
                               "Inserts: {1}\n" +
                               "Updated: {2}\n" +
                               "UnChanged: {3}\n", 
            "CountryQueryToCustomTableExecuteCompletedEvent", payload.Inserts, payload.Updates, payload.Unchanged);
        return Task.CompletedTask;
    }
}