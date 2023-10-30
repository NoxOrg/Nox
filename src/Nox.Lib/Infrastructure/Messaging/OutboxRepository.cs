using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nox.Abstractions;
using Nox.Application;
using Nox.Solution;
using System.Net.Mime;

namespace Nox.Infrastructure.Messaging
{
    internal class OutboxRepository : IOutboxRepository
    {
        private readonly IPublishEndpoint _bus;
        private readonly ILogger<OutboxRepository> _logger;
        private readonly IUserProvider _userProvider;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OutboxRepository(
            IPublishEndpoint bus,
            ILogger<OutboxRepository> logger,
            IUserProvider userProvider,
            IWebHostEnvironment webHostEnvironment)
        {
            _bus = bus;
            _logger = logger;
            _userProvider = userProvider;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AddAsync<T>(T integrationEvent) where T : IIntegrationEvent
        {
            _logger.LogInformation($"Publish message {typeof(T)} to {_bus.GetType()}");

            var prefix = _webHostEnvironment.EnvironmentName == Environments.Production ? string.Empty : $"{_webHostEnvironment.EnvironmentName.ToLower()}.";

            await _bus.Publish(new CloudEventMessage(integrationEvent, _userProvider.GetUser().ToString(), prefix), sendContext =>
            {
                sendContext.ContentType = new ContentType("application/cloudevents+json");
            });

            _logger.LogInformation("Publish message {typeName} in PublishEndpoint ", typeof(T));
        }
    }
}