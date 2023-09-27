using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using MudBlazor.Services;
using Nox;
using Cryptocash.Ui.Generated.Data.Helper;

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
builder.Services.AddMudServices();
builder.Services.AddTransient<NavigationHelper>();

builder.Services.AddNox();

var app = builder.Build();

app.UseNox();

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
