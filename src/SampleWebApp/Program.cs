using Microsoft.AspNetCore.OData;
using Nox;
using Nox.Abstractions;
using Nox.Solution;
using SampleWebApp;
using SampleWebApp.Application;
using SampleWebApp.Presentation.Api.OData;
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
builder.Services.AddAutoMapper(typeof(Program));

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

app.UseODataRouteDebug();

app.UseNox();

app.SeedDataIfNeed();

app.Run();