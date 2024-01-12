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
    INoxUseOptions UseHealthChecks(bool use);

    /// <summary>    
    /// Use Nox Solution configured Monitoring, <see cref="Nox.Solution.Models.Infrastructure.Monitoring.Monitoring"/>
    /// True by default
    /// </summary>
    INoxUseOptions UseMonitoring(bool use);

    /// <summary>
    /// Enables Odata API Page with all end points
    /// </summary>
    INoxUseOptions UseODataRouteDebug();

    INoxUseOptions UseEtlBox(bool checkLicense);
}