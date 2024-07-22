namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxEtlMessagePublisher
{
    Task PublishAsync<TMessage>(TMessage message) where TMessage: class;
    Task PublishAsync<TMessage>(List<TMessage> messages) where TMessage: class;

    Task SendAsync<TMessage>(TMessage message) where TMessage : class;
    
    Task SendAsync<TMessage>(List<TMessage> messages) where TMessage: class;
}