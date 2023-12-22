namespace Nox.Domain;

/// <summary>
/// etags help to prevent simultaneous updates of a resource from overwriting each other - mid-air colissions
/// </summary>
public interface IEtag
{
    /// <summary>
    /// The version of the resource
    /// </summary>
    System.Guid Etag { get; }
}
