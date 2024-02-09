using Hangfire;
using Hangfire.Dashboard;
using Hangfire.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nox.Application.Jobs;

namespace Nox.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseNoxJobs(this IApplicationBuilder app, IHostEnvironment hostingEnvironment)
    {
        var scope = app.ApplicationServices.CreateScope();
        try
        {
            var jobScheduler = scope.ServiceProvider.GetService<IJobScheduler>();
            // Jobs are not being used
            if (jobScheduler is null)
            {
                return;
            }
            SyncJobsInHangFire(scope.ServiceProvider.GetRequiredService<IJobRegistry>() , scope.ServiceProvider.GetRequiredService<IRecurringJobManager>());
        }
        finally 
        {
            scope?.Dispose();
        }                  

        if (hostingEnvironment.IsDevelopment())
        {
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new AnonymousAuthorization() },
            });
        }
    }

    private static void SyncJobsInHangFire(IJobRegistry jobRegistry, IRecurringJobManager recurringJobManager)
    {
        var jobsRegistration = jobRegistry.GetAllJobs();
        //Update Jobs
        foreach (var job in jobsRegistration)
        {
            recurringJobManager.AddOrUpdate<IJobScheduler>(job.JobName, jobScheduler => jobScheduler.Run(job.JobName), job.RecurrentCronExpression);
        }
        var allJos = JobStorage.Current.GetConnection().GetRecurringJobs();

        //Delete Unknown Jobs
        foreach (var jobId in allJos.Select(job=>job.Id))
        {
            if (!jobsRegistration.Any(j => j.JobName == jobId))
            {
                recurringJobManager.RemoveIfExists(jobId);
            }
        }
    }
}

public class AnonymousAuthorization : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        return true;
    }
}
