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
    private bool _useNoxElasticMonitoring = false;
    private bool _useSerilogRequestLogging = true;
    private bool _useEtlBox = false;
    private bool _useHealthChecks = true;


    public INoxUseOptions UseNoxElasticMonitoring()
    {
        _useNoxElasticMonitoring = true;       
        return this;
    }

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

        //Middleware order is important
        //1. Exception
        //2. HealthChecks
        //3. Version
        //4. Routing Mechanism

        builder.UseMiddleware<NoxExceptionHanderMiddleware>();
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

        builder.UseWhen(context => context.Request.Path.StartsWithSegments("/version"), appBuilder =>
        {
            appBuilder.UseMiddleware<VersionMiddleware>();
        });

        var solution = builder.ApplicationServices.GetRequiredService<NoxSolution>();
        var apiPrefix = solution.Presentation.ApiConfiguration.ApiRoutePrefix;

        builder.UseWhen(context => context.Request.Path.StartsWithSegments(apiPrefix) && solution.Domain is not null,
            appBuilder =>
            {
                if (RelatedEntityRoutingMiddleware.IsApplicable(solution))
                { 
                    appBuilder.UseMiddleware<RelatedEntityRoutingMiddleware>();
                }
                appBuilder.UseMiddleware<ApiRoutingMiddleware>();                    
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
        if(_useNoxElasticMonitoring)
        {
            builder.UseNoxAllElasticApm();
        }

        var hostingEnvironment = builder
            .ApplicationServices
            .GetRequiredService<IHostEnvironment>();

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
}