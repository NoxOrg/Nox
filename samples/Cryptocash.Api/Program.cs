using Microsoft.AspNetCore.OData;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Nox;
using System;
using Cryptocash.DataSeed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDataSeeders();

builder.AddNox();

//builder.AddNox((noxOptions) => noxOptions.WithoutNoxLogging());

//builder.AddNox((noxOptions) => noxOptions.WithNoxLogging((loggerConfiguration) =>
//    loggerConfiguration.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day))
//);

var app = builder.Build();

// For Development only
//{
//    using var scope = app.Services.CreateScope();
//    var dbContext = scope.ServiceProvider.GetRequiredService<Cryptocash.Infrastructure.Persistence.AppDbContext>();

//    dbContext.Database.EnsureDeleted();
//    dbContext.Database.EnsureCreated();
//}

if (app.Environment.IsDevelopment())
{
     app.SeedDataIfRequired();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseNox();

app.MapControllers();


app.Run();