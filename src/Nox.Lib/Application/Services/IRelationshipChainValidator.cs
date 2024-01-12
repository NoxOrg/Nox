namespace Nox.Application.Services;

public interface IRelationshipChainValidator
{
    public bool IsValid(RelationshipChain request);
}
 
public partial record RelationshipChain(string EntityName, string EntityKey, params (string NavigationName, string NavigationKey)[] SortedNavigationProperties);