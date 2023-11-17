namespace Nox.Application;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class IntegrationEventTypeAttribute : Attribute
{
    public IntegrationEventTypeAttribute(string eventName, string domainContext)
    {
        EventName = eventName;
        DomainContext = domainContext;
    }

    public string EventName { get; private set; }
    /// <summary>
    /// Domain context should have one of this value types: EntityName | BussinessProcessName | BoundedContext
    /// </summary>
    public string DomainContext { get; private set; }
}
