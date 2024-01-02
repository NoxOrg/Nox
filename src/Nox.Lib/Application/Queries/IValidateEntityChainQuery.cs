namespace Nox.Application.Queries;

public interface IValidateEntityChainQueryHandler
{
    public bool Handle(ValidateEntityChainQuery request);
}

public partial record ValidateEntityChainQuery(string EntityName, string EntityKey, params (string NavigationName, string NavigationKey)[] NavigationProperties);