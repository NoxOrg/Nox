using Cryptocash.Integration.Integrations;
using MediatR;

namespace Cryptocash.Integration.Listeners;

public class CountryQueryToCustomTableEtlRecordCreatedEventHandler: INotificationHandler<CountryQueryToCustomTableEtlRecordCreatedEvent>
{
    private readonly ILogger _logger;

    public CountryQueryToCustomTableEtlRecordCreatedEventHandler(ILogger<CountryQueryToCustomTableEtlRecordCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(CountryQueryToCustomTableEtlRecordCreatedEvent notification, CancellationToken cancellationToken)
    {
        var payload = (CountryQueryToCustomTableRecordCreatedPayload)notification.Payload!;
        _logger.LogInformation("Received: {0}\n " +
                               "Payload\n" +
                               "------------------------------\n" +
                               "Id: {1}\n" +
                               "Name: {2}\n" +
                               "Population: {3}\n" +
                               "CreateDate: {4}\n" +
                               "EditDate: {5}\n", 
            "CountryQueryToCustomTableEtlRecordCreatedEvent", payload.Id, payload.Name, payload.Population, payload.CreateDate, payload.EditDate);
        return Task.CompletedTask;
    }
}