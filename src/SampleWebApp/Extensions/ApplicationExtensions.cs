namespace SampleWebApp;

public static class ApplicationExtensions
{
    public static void UseNoxErrorHandling(this IApplicationBuilder app)
    {
        app.UseMiddleware<NoxExceptionHanderMiddleware>();
    }
}