using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Solution;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Presentation.Api.OData;

using SampleWebApp.Application;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;
using Nox.Abstractions;

var builder = WebApplication.CreateBuilder(args);
builder.AddNox();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddNox();

builder.Services.AddScoped<GetCountriesByContinentQueryBase, GetCountriesByContinentQuery>();
builder.Services.AddScoped<UpdatePopulationStatisticsCommandHandlerBase, UpdatePopulationStatisticsCommandHandler>();
builder.Services.AddScoped<INoxMessenger, NoxMessenger>();

ODataConfiguration.Register(builder.Services);

var app = builder.Build();

/*===================== Enable for Tests Purposes Only*/

//SqliteConnection connection = new SqliteConnection("DataSource=:memory:");
//SqliteConnection connection = new SqliteConnection(@"DataSource=test.db");

//connection.Open();

//var options = new DbContextOptionsBuilder<SampleWebAppDbContext>()
//    .UseSqlite(connection)
//    .Options;

//var dbContext = new SampleWebAppDbContext(options,
//    app.Services.GetRequiredService<NoxSolution>(),
//    new SqliteDatabaseConfigurator());

//dbContext.Database.EnsureCreated();
/*=====================*/


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

app.Run();
