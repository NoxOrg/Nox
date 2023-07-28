using Nox.Abstractions;
using Nox.Logging.Serilog;
using Nox.Monitoring.ElasticApm;
using SampleWebApp;
using SampleWebApp.Application;
using SampleWebApp.SeedData;

var builder = WebApplication.CreateBuilder(args);

builder.AddNox();

//Add this if you want to use Serilog for logging and elastic Apm for monitoring
builder.UseSerilog(opt =>
{
    opt.WithElasticApm();
    opt.WithEcsHttpContext();
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<GetCountriesByContinentQueryBase, GetCountriesByContinentQuery>();
builder.Services.AddScoped<UpdatePopulationStatisticsCommandHandlerBase, UpdatePopulationStatisticsCommandHandler>();
builder.Services.AddScoped<INoxMessenger, NoxMessenger>();

builder.AddSeedData();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseNoxErrorHandling();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//Add this to use elastic Apm monitoring
//app.UseElasticMonitoring();

app.SeedDataIfNeed();

app.Run();