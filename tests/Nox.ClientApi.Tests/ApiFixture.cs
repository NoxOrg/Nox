using AutoFixture;
using ClientApi.Presentation.Api.OData;
using ClientApi.Infrastructure.Persistence;

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

            //app.Run();
        }

        public IServiceProvider ServiceProvider => app!.Services;
        public ClientDatabaseNumbersController? ClientDatabaseNumbersController => ServiceProvider?.GetService<ClientDatabaseNumbersController>();
        public ClientNuidsController? ClientNuidsController => ServiceProvider?.GetService<ClientNuidsController>();

        public IFixture Fixture { get; }

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
