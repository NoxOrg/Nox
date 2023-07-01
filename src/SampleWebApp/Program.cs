using System.Diagnostics.Metrics;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Solution;
using Nox.Types.EntityFramework.Sqlite;
using Nox.Types.EntityFramework.Sqlite.ToMoveEF;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Presentation.Api.OData;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ODataConfiguration.Register(builder.Services);

builder.Services.AddNox();

// Just for demo, would be define in AddNox
builder.Services.AddSingleton<INoxDatabaseConfiguration, SqliteDatabaseConfiguration>();
// Just for demo, would be define in AddNox
// NoxSolution could be retrieve from a function in NoxSolution...
builder.Services.AddSingleton(new NoxSolution());

var app = builder.Build();

/**/

SqliteConnection connection = new SqliteConnection("DataSource=:memory:");
connection.Open();
var options = new DbContextOptionsBuilder<SampleWebAppDbContext>()
    .UseSqlite(connection)
    .Options;

//TODO the IEntityTypeConfiguration are not being resolved, they need to be set properly in the container
// Example:https://github.com/dotnet/efcore/issues/23103
var dbContext = new SampleWebAppDbContext(options);
dbContext.Database.EnsureCreated();

/**/


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
