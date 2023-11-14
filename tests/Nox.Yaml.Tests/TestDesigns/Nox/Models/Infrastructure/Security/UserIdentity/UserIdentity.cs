using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Enums;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[Title("Configuration for the end-user identity provider.")]
[Description("Specify the settings required to authenticate the application to the end-user identity provider.")]
[AdditionalProperties(false)]
public class UserIdentity
{

    [Required]
    [Title("The user identity provider.")]
    [Description("Specify the provider that will be used to authenticate end-users.")]
    public UserIdentityProvider Provider { get; internal set; }

    [IfEquals(nameof(Provider), UserIdentityProvider.AzureAd)]
    public AzureAdProviderOptions? AzureAdOptions { get; internal set; }
}