using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.Net;

using Nox.Middlewares;
using Nox.Solution;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace Nox.Lib.Tests.Middlewares
{
    public class SecureGeneratedEndPointsMiddlewareTests
    {
        [Theory]
        [InlineData("Countries",HttpStatusCode.OK)]
        /// <summary>
        /// Custom EndPoints are always available
        /// </summary>
        [InlineData("CustomEndPoint", HttpStatusCode.OK)]
        [InlineData("Cities", HttpStatusCode.NotFound)]
        [InlineData("People", HttpStatusCode.OK)]

        public async Task MiddlewareTest_ReturnsNotFoundForGetRequest(string relativeUrl, HttpStatusCode expectedCode)
        {
            using IHost host = await ConfigureHost();

            var response = await host.GetTestClient().GetAsync($"/api/v1/{relativeUrl}");

            response.StatusCode.Should().Be(expectedCode);
        }
        [Theory]
        [InlineData("Countries", HttpStatusCode.OK)]
        /// <summary>
        /// Custom EndPoints are always available
        /// </summary>
        [InlineData("CustomEndPoint", HttpStatusCode.OK)]
        [InlineData("Cities", HttpStatusCode.OK)]
        [InlineData("People", HttpStatusCode.NotFound)]
        public async Task MiddlewareTest_ReturnsNotFoundForPostRequest(string relativeUrl, HttpStatusCode expectedCode)
        {
            using IHost host = await ConfigureHost();

            var response = await host.GetTestClient().PostAsync($"/api/v1/{relativeUrl}", null);

            response.StatusCode.Should().Be(expectedCode);
        }
        [Theory]
        [InlineData("Countries", HttpStatusCode.OK)]
        /// <summary>
        /// Custom EndPoints are always available
        /// </summary>
        [InlineData("CustomEndPoint", HttpStatusCode.OK)]
        [InlineData("Cities", HttpStatusCode.NotFound)]
        [InlineData("People", HttpStatusCode.OK)]
        public async Task MiddlewareTest_ReturnsNotFoundForPutAndPatchRequest(string relativeUrl, HttpStatusCode expectedCode)
        {
            using IHost host = await ConfigureHost();

            var response = await host.GetTestClient().PutAsync($"/api/v1/{relativeUrl}", null);
            var responsePatch = await host.GetTestClient().PatchAsync($"/api/v1/{relativeUrl}", null);

            response.StatusCode.Should().Be(expectedCode);
            responsePatch.StatusCode.Should().Be(expectedCode);
        }

        [Theory]
        [InlineData("Countries", HttpStatusCode.OK)]
        /// <summary>
        /// Custom EndPoints are always available
        /// </summary>
        [InlineData("CustomEndPoint", HttpStatusCode.OK)]
        [InlineData("Cities", HttpStatusCode.OK)]
        [InlineData("People", HttpStatusCode.NotFound)]
        public async Task MiddlewareTest_ReturnsNotFoundForDeleteRequest(string relativeUrl, HttpStatusCode expectedCode)
        {
            using IHost host = await ConfigureHost();

            var response = await host.GetTestClient().DeleteAsync($"/api/v1/{relativeUrl}");

            response.StatusCode.Should().Be(expectedCode);
        }

        private static async Task<IHost> ConfigureHost()
        {
            return await new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder
                        .UseTestServer()
                        .ConfigureServices(services =>
                        {
                            var solutionBuilder = new NoxSolutionBuilder().WithFile($"./files/SecureGeneratedEndPointsMiddlewareTests.solution.nox.yaml");
                            var noxSolution = solutionBuilder.Build();

                            services.AddSingleton<NoxSolution>(noxSolution);
                        })
                        .Configure(app =>
                        {
                            app.UseMiddleware<SecureGeneratedEndPointsMiddleware>();
                            app.Run(async (context) =>
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.OK;
                                await context.Response.WriteAsync("SecureGeneratedEndPointsMiddleware Request Allowed");
                            });
                        });
                })
                .StartAsync();
        }
    }
}
