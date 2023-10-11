using Nox.Application;

namespace Nox.Messaging;

public interface IOutboxRepository
{
    Task AddAsync<T>(T integrationEvent) where T : IIntegrationEvent;
}