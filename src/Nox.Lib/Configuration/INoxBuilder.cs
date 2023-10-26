namespace Nox;

public interface INoxBuilder
{
    INoxBuilder UseNoxElasticMonitoring();

    INoxBuilder UseODataRouteDebug();

    INoxBuilder UseEtlBox(bool checkLicense);
}