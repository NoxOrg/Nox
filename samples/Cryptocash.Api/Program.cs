using Nox;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.AddNox(opts => opts.WithSwagger());

var app = builder.Build();

var isDevelopment = app.Environment.IsDevelopment();

app.UseNox(useSwagger: isDevelopment);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();