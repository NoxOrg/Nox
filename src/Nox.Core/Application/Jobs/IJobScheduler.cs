using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nox.Application.Jobs
{
    /// <summary>
    /// Jobs scheduling and execution
    /// </summary>
    public interface IJobScheduler
    {
        /// <summary>
        /// Run a job by name
        /// </summary>
        void Run(string jobName);
    }
}
