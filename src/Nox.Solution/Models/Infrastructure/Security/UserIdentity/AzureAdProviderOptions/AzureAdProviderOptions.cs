using Nox.Yaml.Attributes;
using System;

namespace Nox.Solution;

[Title("The options to connect to the Azure AD identity provider.")]
[Description("Specify the properties required to connect the application with the Azure AD identity provider. See https://learn.microsoft.com/en-us/azure/api-management/api-management-howto-protect-backend-with-aad")]
[AdditionalProperties(false)]
public class AzureAdProviderOptions
{
    
    [Required]
    [Title("The URL of the Azure AD instance.")]
    [Description("The URL of the Azure AD instance that your application should use for authentication. It typically has a format like https://login.microsoftonline.com/.")]
    public Uri Instance { get; private set; } = null!;

    [Required]
    [Title("The domain name associated with your Azure AD tenant.")]
    [Description("Used to define the domain name associated with your Azure AD tenant.")]
    public string Domain { get; private set; } = null!;
    
    [Required]
    [Title("The GUID that uniquely identifies your Azure AD tenant.")]
    [Description("The GUID that uniquely identifies your Azure AD tenant. It's sometimes referred to as the Directory ID.")]
    public Guid TenantId { get; private set; } = default;

    [Required]
    [Title("The Application ID of your registered application in Azure AD.")]
    [Description("The Application ID of your registered application in Azure AD. The application ID is used to identify your application when it communicates with Azure AD.")]
    public Guid ClientId { get; private set; } = default;

    [Required]
    [Title("The URL path where Azure AD should redirect users after sign-in.")]
    [Description("The URL path that Azure AD should redirect users to after they have signed in. It's often set to something like /signin-oidc.")]
    public Uri CallbackPath { get; private set; } = null!;

    [Required]
    [Title("The URL path where Azure AD should redirect users after sign-out.")]
    [Description("the URL path to which Azure AD should redirect users after they have signed out from the application. This callback path is used to handle post-sign-out actions and provide a seamless user experience during the sign-out process.")]
    public Uri SignedOutCallbackPath { get; private set; } = null!;
}