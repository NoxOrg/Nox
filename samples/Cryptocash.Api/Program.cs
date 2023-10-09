using Nox;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.AddNox(opts => opts.WithSwagger());

//builder.AddNox((noxOptions) => noxOptions.WithoutNoxLogging());

//builder.AddNox((noxOptions) => noxOptions.WithNoxLogging((loggerConfiguration) => 
//    loggerConfiguration.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day))
//);


var app = builder.Build();

var isDevelopment = app.Environment.IsDevelopment();

app.UseNox(useSwagger: isDevelopment);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();