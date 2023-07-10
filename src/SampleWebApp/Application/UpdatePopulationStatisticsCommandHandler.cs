﻿using Nox.Abstractions;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application
{
    public class UpdatePopulationStatisticsCommandHandler : UpdatePopulationStatisticsCommandHandlerBase
    {
        public UpdatePopulationStatisticsCommandHandler(SampleWebAppDbContext dbContext, INoxMessenger messenger) : base(dbContext, messenger)
        {
        }

        public override Task<INoxCommandResult> ExecuteAsync(UpdatePopulationStatistics command)
        {
            throw new NotImplementedException();
        }
    }
}
