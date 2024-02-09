using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Nox.Monitoring.ElasticApm;
using Nox.Integration.Extensions;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nox.Integration.Abstractions;
using Nox.Lib;
using Serilog;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Nox.Middlewares;
using Nox.Solution;
using Microsoft.Extensions.Logging;
using Elastic.Apm.NetCoreAll;
using Nox.Extensions;

namespace Nox;

internal class NoxUseOptions : INoxUseOptions
{
#if DEBUG
    private bool _useODataRouteDebug = true;
    private bool _useEtlBoxCheckLicense = false;
#else
    private bool _useODataRouteDebug = false;
    private bool _useEtlBoxCheckLicense = true;
#endif
    private bool _useSerilogRequestLogging = true;
    private bool _useEtlBox = false;
    private bool _useHealthChecks = true;
    private bool _useMonitoring = true;

    public INoxUseOptions UseODataRouteDebug()
    {
        _useODataRouteDebug = true;
        return this;
    }
    public INoxUseOptions UseHealthChecks(bool use)
    {
        _useHealthChecks = use;
        return this;
    }
    public INoxUseOptions UseMonitoring(bool use)
    {
        _useMonitoring = use;
        return this;
    }
    public INoxUseOptions UseRequestLogging(bool use)
    {
        _useSerilogRequestLogging = use;
        return this;
    }

    public INoxUseOptions UseEtlBox(bool checkLicense)
    {
        _useEtlBox = true;
        _useEtlBoxCheckLicense = checkLicense;

        return this;
    }
    public void Configure(IApplicationBuilder builder)
    {
        if (_useSerilogRequestLogging)
            builder.UseSerilogRequestLogging();

        var logger = builder.ApplicationServices.GetRequiredService<ILogger<NoxUseOptions>>();

        //Middleware order is important
        //1. Exception
        //2. HealthChecks
        //3. Version
        //4. Routing Mechanism
        builder.UseMiddleware<ExceptionHanderMiddleware>();

        ConfigureHealthChecks(builder);        

        builder.UseWhen(context => context.Request.Path.StartsWithSegments("/version"), appBuilder =>
        {
            appBuilder.UseMiddleware<VersionMiddleware>();
        });

        var solution = builder.ApplicationServices.GetRequiredService<NoxSolution>();
        var apiPrefix = solution.Presentation.ApiConfiguration.ApiRoutePrefix;

        builder.UseWhen(context => context.Request.Path.StartsWithSegments(apiPrefix) && solution.Domain is not null,
            appBuilder =>
            {
                if (SecureGeneratedEndPointsMiddleware.IsApplicable(solution))
                {
                    appBuilder.UseMiddleware<SecureGeneratedEndPointsMiddleware>();
                    logger.LogInformation("Using SecureGeneratedEndPointsMiddleware middleware");
                }
                else
                {
                    logger.LogInformation("Skipping SecureGeneratedEndPointsMiddleware middleware");
                }
                if (RelatedEntityRoutingMiddleware.IsApplicable(solution))
                {
                    appBuilder.UseMiddleware<RelatedEntityRoutingMiddleware>();
                    logger.LogInformation("Using RelatedEntityRoutingMiddleware middleware");
                }
                else
                {
                    logger.LogInformation("Skipping RelatedEntityRoutingMiddleware middleware");
                }
                if (ApiRoutingMiddleware.IsApplicable(solution))
                {
                    appBuilder.UseMiddleware<ApiRoutingMiddleware>();
                    logger.LogInformation("Using ApiRoutingMiddleware  middleware");
                }
                else
                {
                    logger.LogInformation("Skipping ApiRoutingMiddleware middleware");
                }
            });

        builder.UseRouting();

        if (_useODataRouteDebug)
        {
            builder.UseODataRouteDebug();
        }
        if (_useEtlBox)
        {
            builder.ApplicationServices.UseEtlBox(_useEtlBoxCheckLicense);
        }

        ConfigureMonitoring(builder, solution);


        var hostingEnvironment = builder
            .ApplicationServices
            .GetRequiredService<IHostEnvironment>();

        builder.UseNoxJobs(hostingEnvironment);

        var isDevelopment = hostingEnvironment.IsDevelopment();
        if (isDevelopment)
        {
            builder.UseSwagger();
            builder.UseSwaggerUI();
        }

        var integrationContext = builder
            .ApplicationServices
            .GetService<INoxIntegrationContext>();

        integrationContext?.ExecuteStartupIntegrations();
    }

   

    private void ConfigureHealthChecks(IApplicationBuilder builder)
    {
        if (_useHealthChecks && builder is IEndpointRouteBuilder endpointRouteBuilder)
        {
            // aggregates all IHealthChecks...
            endpointRouteBuilder.MapHealthChecks("/healthz", new HealthCheckOptions
            {
                Predicate = healthCheck => !healthCheck.Tags.Contains("ready")
            });
            //liveness probe
            //No Custom Health Check, service is live
            endpointRouteBuilder.MapHealthChecks("/healthz/live", new HealthCheckOptions
            {
                Predicate = _ => false
            });
            //readiness probe
            endpointRouteBuilder.MapHealthChecks("/healthz/ready", new HealthCheckOptions
            {
                Predicate = healthCheck => healthCheck.Tags.Contains("ready")
            });
        }
    }
    private void ConfigureMonitoring(IApplicationBuilder builder, NoxSolution noxSolution)
    {
        if (!_useMonitoring)
            return;

        if (noxSolution.Infrastructure?.Monitoring is null)
        {
            return;
        }

        switch (noxSolution.Infrastructure.Monitoring.Provider)
        {
            case MonitoringProvider.ElasticApm:
                builder.UseAllElasticApm(noxSolution.Infrastructure.Monitoring.ElasticApmServer!.ToConfiguration());
                break;
            default:
                throw new NotImplementedException($"Unknown provider {noxSolution.Infrastructure.Monitoring.Provider}");
            }
    }
}