using MassTransit;

namespace Nox.Integration.Abstractions.Interfaces;

public interface IMassTransitTransport
{
    IBusControl BusControl { get; }
}