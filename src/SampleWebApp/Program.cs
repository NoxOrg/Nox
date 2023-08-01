using Nox;
using Nox.Abstractions;
using SampleWebApp;

//Include this if you want to use Serilog for logging and elastic Apm for monitoring
// using Nox.Logging.Serilog;
// using Nox.Monitoring.ElasticApm;
//===================================================================================
using SampleWebApp.Application;
using SampleWebApp.SeedData;
using SampleWebApp.Application.Queries;
using MediatR;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.AddNox();

//Include this if you want to use Serilog for logging and elastic Apm for monitoring
// builder.UseNoxSerilogLogging(opt =>
// {
//     opt.WithElasticApm();
//     opt.WithEcsHttpContext();
// });
//===================================================================================

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ======================================================
// SAMPLE WEB APP Extensions
builder.Services
    .AddScoped<GetCountriesByContinentQueryBase, GetCountriesByContinentQuery>()
    .AddScoped<UpdatePopulationStatisticsCommandHandlerBase, UpdatePopulationStatisticsCommandHandler>()
    .AddScoped<INoxMessenger, NoxMessenger>()
    .AddSecurityValidators();
// ======================================================

builder.AddSeedData();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseNox();
//Include this to use elastic Apm monitoring
//app.UseNoxElasticMonitoring();
//==========================================

app.SeedDataIfNeed();

app.Run();