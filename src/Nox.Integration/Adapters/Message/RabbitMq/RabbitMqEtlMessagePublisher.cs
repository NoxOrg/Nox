using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Adapters.Message.RabbitMq;

public class RabbitMqEtlMessagePublisher: INoxEtlMessagePublisher
{
    private readonly IMassTransitTransport _transport;

    public RabbitMqEtlMessagePublisher(IMassTransitTransport transport)
    {
        _transport = transport;
    }
    
    
    public async Task PublishAsync<TMessage>(TMessage message) where TMessage: class
    {
        await _transport.BusControl.Publish(message);
    }

    public async Task PublishAsync<TMessage>(List<TMessage> messages) where TMessage: class
    {
        foreach (var message in messages)
        {
            await _transport.BusControl.Publish(message);
        }
    }

    public async Task SendAsync<TMessage>(TMessage message) where TMessage : class
    {
        var endpoint = await _transport.BusControl.GetSendEndpoint(_transport.BusControl.Address);
        await endpoint.Send(message);
    }

    public async Task SendAsync<TMessage>(List<TMessage> messages) where TMessage : class
    {
        var endpoint = await _transport.BusControl.GetSendEndpoint(_transport.BusControl.Address);
        foreach (var message in messages)
        {
            await endpoint.Send(message);
        }
    }
}