using Microsoft.AspNetCore.OData;
using Nox;
using SampleWebApp;
using SampleWebApp.Application;
using Nox.Abstractions;
using ODataConfiguration = SampleWebApp.Presentation.Api.OData.ODataConfiguration;
using SampleWebApp.SeedData;

var builder = WebApplication.CreateBuilder(args);

builder.AddNox();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<GetCountriesByContinentQueryBase, GetCountriesByContinentQuery>();
builder.Services.AddScoped<UpdatePopulationStatisticsCommandHandlerBase, UpdatePopulationStatisticsCommandHandler>();
builder.Services.AddScoped<INoxMessenger, NoxMessenger>();

builder.AddSeedData();

ODataConfiguration.Register(builder.Services);

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

app.UseODataRouteDebug();

app.UseNox();

app.SeedDataIfNeed();

app.Run();