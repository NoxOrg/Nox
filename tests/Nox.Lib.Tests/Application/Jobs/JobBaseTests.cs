using Microsoft.Extensions.Logging;
using Moq;
using Nox.Application.Jobs;
using Nox.Lib.Tests.FixtureConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nox.Lib.Tests.Application.Jobs
{
    public class JobBaseTests
    {
        [Theory]
        [AutoMoqData]
        public void WhenJobIsNotImplemented_ShouldLogWarning(Mock<ILogger<IJob>> logger)
        {
            // Arrange
            FakeJobWithoutImplementation job = new(logger.Object);

            // Act
            job.Run();

            // Assert
            logger.Verify(logger => logger.Log(
                LogLevel.Warning,
                0,
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()));
        }
        [Theory]
        [AutoMoqData]
        public void WhenJobIsImplemented_ShouldLogInfo(Mock<ILogger<IJob>> logger)
        {
            // Arrange
            FakeJob job = new(logger.Object);

            // Act
            job.Run();

            // Assert
            logger.Verify(logger => logger.Log(
                LogLevel.Information,
                0,
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()));
        }
    }

    public class FakeJobWithoutImplementation:JobBase
    {
        public FakeJobWithoutImplementation(ILogger<IJob> logger) : base(logger)
        {
        }
    }
    public class FakeJob : JobBase
    {
        public FakeJob(ILogger<IJob> logger) : base(logger)
        {
        }
        override public Task Run()
        {
            Logger.LogInformation("Job {jobName} is running", GetType().Name);
            return Task.CompletedTask;
        }
    }
}
