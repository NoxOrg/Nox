namespace Nox.Messaging;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class IntegrationEventTypeAttribute : Attribute
{
    public IntegrationEventTypeAttribute(string eventName, string trait)
    {
        EventName = eventName;
        Trait = trait;
    }

    public string EventName { get; private set; }
    public string Trait { get; private set; }
}
