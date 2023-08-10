using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Nox.Localization.Extensions;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Localization.Tests;

public class WebApplicationFixture
{
    public WebApplication? FixtureWebApplication { get; }

    public WebApplicationFixture()
    {
        // Simulate app startup
        var builder = WebApplication.CreateBuilder();

        var solution = new NoxSolutionBuilder()
            .UseYamlFile("./files/sqlite-localizer.solution.nox.yaml")
            .Build();
        builder.Services.AddSingleton<NoxSolution>(solution);
        
        builder.Services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        
        builder.UseNoxLocalization(opt =>
        {
            opt.WithSqliteStore(solution.Infrastructure!.Dependencies!.UiLocalizations!);
        });

        var app = builder.Build();

        app.UseNox();
        FixtureWebApplication = app;
    }

    public void SetCulture(string? culture)
    {
        if(culture is not null) 
        { 
            CultureInfo.CurrentCulture = new CultureInfo(culture); // http request or message header
        }
    }
}