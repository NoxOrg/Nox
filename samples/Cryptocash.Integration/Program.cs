using Nox;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.AddNox();

//builder.AddNox((noxOptions) => noxOptions.WithoutNoxLogging());

//builder.AddNox((noxOptions) => noxOptions.WithNoxLogging((loggerConfiguration) =>
//    loggerConfiguration.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day))
//);

var app = builder.Build();

app.UseNox();

// For Development only
// {
//     using var scope = app.Services.CreateScope();
//     var dbContext = scope.ServiceProvider.GetRequiredService<CryptocashIntegration.Infrastructure.Persistence.AppDbContext>();
//
//     dbContext.Database.EnsureDeleted();
//     dbContext.Database.EnsureCreated();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();