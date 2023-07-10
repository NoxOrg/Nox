using Nox;
using SampleWebApp;
using SampleWebApp.Application;
using Nox.Abstractions;
using ODataConfiguration = SampleWebApp.Presentation.Api.OData.ODataConfiguration;

var builder = WebApplication.CreateBuilder(args);

builder.AddNox();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ODataConfiguration.Register(builder.Services);

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
