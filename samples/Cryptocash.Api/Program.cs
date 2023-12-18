using Nox;
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


if (app.Environment.IsDevelopment())
{
    app.SeedDataIfRequired();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseNox();

app.MapControllers();

app.Run();