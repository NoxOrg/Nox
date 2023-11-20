using Nox.Yaml.Attributes;

namespace Nox.Solution;

[Title("Configuration for the end-user identity provider.")]
[Description("Specify the settings required to authenticate the application to the end-user identity provider.")]
[AdditionalProperties(false)]
public class UserIdentity
{

    [Required]
    [Title("The user identity provider.")]
    [Description("Specify the provider that will be used to authenticate end-users.")]
    public UserIdentityProvider Provider { get; internal set; }

    [IfEquals("Provider", UserIdentityProvider.AzureAd)]
    public AzureAdProviderOptions? AzureAdOptions { get; internal set; }
}