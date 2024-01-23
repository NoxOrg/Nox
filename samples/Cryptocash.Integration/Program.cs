using Cryptocash.Integration.Integrations;
using Cryptocash.Integration.Integrations.TransformHandlers;
using Nox;
using Nox.Integration.Abstractions.Models;
using Nox.Integration.Extensions;

using CryptocashIntegration.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.AddNox();

//You have to register all your integration transformation handlers.
builder.Services.RegisterTransformHandler<QueryToCustomTableTransformHandler>();
builder.Services.RegisterTransformHandler<JsonToTableTransformHandler>();

//builder.AddNox((noxOptions) => noxOptions.WithoutNoxLogging());

//builder.AddNox((noxOptions) => noxOptions.WithNoxLogging((loggerConfiguration) =>
//    loggerConfiguration.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day))
//);

var app = builder.Build();

var events = app.Services.GetServices<EtlExecuteCompletedEvent>();

app.UseNox();

// For Development only
// {
//     using var scope = app.Services.CreateScope();
//     var dbContext = scope.ServiceProvider.GetRequiredService<CryptocashIntegration.Infrastructure.Persistence.AppDbContext>();
//
//     dbContext.Database.EnsureDeleted();
//     dbContext.Database.EnsureCreated();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();