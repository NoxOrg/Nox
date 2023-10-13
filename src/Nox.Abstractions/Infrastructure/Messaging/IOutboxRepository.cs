using Nox.Application;

namespace Nox.Infrastructure.Messaging;

public interface IOutboxRepository
{
    Task AddAsync<T>(T integrationEvent) where T : IIntegrationEvent;
}