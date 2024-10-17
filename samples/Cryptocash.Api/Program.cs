using Nox;
using Cryptocash.DataSeed;
using Cryptocash.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDataSeeders();

builder.AddNox();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    try
    {
        app.SeedDataIfRequired();
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "Error seeding data");
        throw;
    }   
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseNox(app.Environment);

app.MapControllers();

app.Run();