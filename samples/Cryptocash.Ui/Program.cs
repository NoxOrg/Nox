using Microsoft.Identity.Web;
using Cryptocash.Ui.Generated.Data.Helper;
using System.Text.Json.Serialization;
using Cryptocash.Ui.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
ConfigurationHelper.Configuration = configuration;

//Note: Auth section disabled for now until YAML config agreed and available for Auth
// Add services to the container. 
//builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAd"));
//builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();

//builder.Services.AddAuthorization(options =>
//{
//    // By default, all incoming requests will be authorized according to the default policy
//    options.FallbackPolicy = options.DefaultPolicy;
//});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();
builder.Services.AddTransient<NavigationHelper>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

builder.Services.AddNoxUi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
