namespace Nox;

public interface INoxUseOptions
{
    /// <summary>
    /// Logs all request using Serilog
    /// Requires default log configuration or Custom Serilog configuration
    /// </summary>
    /// <param name="use">True to use it </param>
    INoxUseOptions UseRequestLogging(bool use);

    /// <summary>    
    /// Enables healthy check in /healthz
    /// Enables Liveness in /healthz/live
    /// Enables Readiness in /healthz/ready (For readiness add HealthChecks with the tag "ready", otherwise is ready always ready)
    /// </summary>
    /// <param name="use"></param>
    INoxUseOptions UseHealthChecks(bool use);

    INoxUseOptions UseNoxElasticMonitoring();

    /// <summary>
    /// Enables Odata API Page with all end points
    /// </summary>
    INoxUseOptions UseODataRouteDebug();

    INoxUseOptions UseEtlBox(bool checkLicense);
}