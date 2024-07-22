using ETLBox.DataFlow;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Types;
using Uri = System.Uri;

namespace Nox.Integration.Adapters.Message.RabbitMq;

public class RabbitMqTargetAdapter<TTarget> : 
    RabbitMqTargetAdapterBase, 
    INoxEtlMessageTargetAdapter<TTarget>
{
    public CustomDestination<TTarget> MetricsTarget => CreateMetricsTarget();

    public CustomDestination<TTarget> Target => CreateTarget();

    private CustomDestination<TTarget> CreateMetricsTarget()
    {
        return new CustomDestination<TTarget>
        {
            WriteAction = MetricsWriteAction
        };
    }

    private CustomDestination<TTarget> CreateTarget()
    {
        return new CustomDestination<TTarget>
        {
            WriteAction = TargetWriteAction
        };
    }

    public RabbitMqTargetAdapter(Uri uri, IReadOnlyList<NoxSimpleTypeDefinition> messageAttributes) : base(uri, messageAttributes)
    {

    }
}