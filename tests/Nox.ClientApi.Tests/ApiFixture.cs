using AutoFixture;
using ClientApi.Presentation.Api.OData;
using ClientApi.Infrastructure.Persistence;
using Moq;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace Nox.ClientApi.Tests
{
    public sealed class ApiFixture : IDisposable
    {
        private WebApplication? app;

        private bool disposedValue;

        public ApiFixture(IFixture fixture)
        {
            Fixture = fixture;

            var builder = WebApplication.CreateBuilder();

            builder.AddNox();

            // Manually Register the Controllers
            builder.Services.AddSingleton<ClientDatabaseNumbersController>();
            builder.Services.AddSingleton<ClientNuidsController>();

            app = builder.Build();

            app.UseNox();

            var clientApiDbContext =  app.Services.GetService<ClientApiDbContext>();

            clientApiDbContext!.Database.EnsureDeleted();
            clientApiDbContext!.Database.EnsureCreated();

            var serviceProvider = app.Services;

            ClientDatabaseNumbersController = CreateController<ClientDatabaseNumbersController>(serviceProvider);
            ClientNuidsController = CreateController<ClientNuidsController>(serviceProvider);
            //app.Run();
        }

        public ClientDatabaseNumbersController ClientDatabaseNumbersController { get; }
        public ClientNuidsController ClientNuidsController { get; }

        public IFixture Fixture { get; }


        private static TController CreateController<TController>(IServiceProvider serviceProvider)
            where TController : ControllerBase
        {
            var controller = serviceProvider.GetRequiredService<TController>();
            controller.ObjectValidator = new ObjectValidatorFixture();

            return controller;
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (app is IDisposable disposable)
                    {
                        disposable.Dispose();
                        app = null;
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ApiFixture()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}