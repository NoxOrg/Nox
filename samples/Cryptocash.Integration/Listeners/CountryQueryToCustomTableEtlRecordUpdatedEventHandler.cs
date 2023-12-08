using Cryptocash.Integration.Integrations;
using MediatR;

namespace Cryptocash.Integration.Listeners;

public class CountryQueryToCustomTableEtlRecordUpdatedEventHandler: INotificationHandler<CountryQueryToCustomTableEtlRecordUpdatedEvent>
{
    private readonly ILogger _logger;

    public CountryQueryToCustomTableEtlRecordUpdatedEventHandler(ILogger<CountryQueryToCustomTableEtlRecordUpdatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(CountryQueryToCustomTableEtlRecordUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var payload = (CountryQueryToCustomTableRecordUpdatedPayload)notification.Payload!;
        _logger.LogInformation("Received: {0}\n " +
                               "Payload\n" +
                               "------------------------------\n" +
                               //"Id: {1}\n" +
                               "Name: {2}\n" +
                               "Population: {3}\n" +
                               "CreateDate: {4}\n" +
                               "EditDate: {5}\n", 
            "CountryQueryToCustomTableEtlRecordUpdatedEvent", payload.Name, payload.Population, payload.CreateDate, payload.EditDate);
        return Task.CompletedTask;
    }
}