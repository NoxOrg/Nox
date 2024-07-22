using MassTransit;
using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Adapters.Message.RabbitMq;

public sealed class RabbitMqTransport: IMassTransitTransport
{
    private readonly IBusControl _busControl;

    public IBusControl BusControl => _busControl;

    public RabbitMqTransport(Uri hostUri, string userName, string password)
    {
        _busControl = ConfigureBus(hostUri, userName, password);
        _busControl.StartAsync();
    }

    private IBusControl ConfigureBus(Uri hostUri, string userName, string password)
    {
        var busControl = Bus.Factory.CreateUsingRabbitMq(configure =>
        {
            configure.Host(hostUri, host =>
            {
                host.Username(userName);
                host.Password(password);
            });
            
        });
        return busControl;
    }
}