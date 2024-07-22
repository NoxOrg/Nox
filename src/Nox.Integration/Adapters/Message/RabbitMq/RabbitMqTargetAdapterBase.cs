using ETLBox;
using ETLBox.DataFlow;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;
using Nox.Types;
using Uri = System.Uri;

namespace Nox.Integration.Adapters.Message.RabbitMq;

public abstract class RabbitMqTargetAdapterBase
{
    private Uri _uri;
    private IReadOnlyList<NoxSimpleTypeDefinition> _msgAttributes;
    
    public event InsertEventHandler? OnInsert;
    public event UpdateEventHandler? OnUpdate;
    
    public TargetAdapterMetrics Metrics { get; }

    public IntegrationTargetAdapterType AdapterType => IntegrationTargetAdapterType.MessageBroker;

    protected void MetricsWriteAction<TTarget>(TTarget dto, int index)
    {
        var changeActionProperty = dto!.GetType().GetProperty("ChangeAction");
        if (changeActionProperty != null)
        {
            var changeAction = (ChangeAction)changeActionProperty.GetValue(dto)!;
            switch (changeAction)
            {
                case ChangeAction.Insert:
                    RaiseOnInsert(dto);
                    break;
                case ChangeAction.Update:
                    RaiseOnUpdate(dto);
                    break;
                case ChangeAction.Exists:
                    RaiseOnUnchanged();
                    break;
            }
        }
    }

    internal void TargetWriteAction<TTarget>(TTarget dto, int index)
    {
        var changeActionProperty = dto!.GetType().GetProperty("ChangeAction");
        if (changeActionProperty != null)
        {
            var changeAction = (ChangeAction)changeActionProperty.GetValue(dto)!;
            switch (changeAction)
            {
                case ChangeAction.Insert:
                    break;
                case ChangeAction.Update:
                    break;
            }
        }
    }

    protected RabbitMqTargetAdapterBase(Uri uri, IReadOnlyList<NoxSimpleTypeDefinition> messageAttributes)
    {
        _uri = uri;
        _msgAttributes = messageAttributes;
        Metrics = new TargetAdapterMetrics();
    }

    private void RaiseOnInsert(dynamic dataRecord)
    {
        OnInsert?.Invoke(this, new MetricsEventArgs(dataRecord));
        Metrics.Inserts++;
    }

    private void RaiseOnUpdate(dynamic dataRecord)
    {
        OnUpdate?.Invoke(this, new MetricsEventArgs(dataRecord));
        Metrics.Updates++;
    }

    private void RaiseOnUnchanged()
    {
        Metrics.Unchanged++;
    }
    
    
}