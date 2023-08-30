using System.Net.Http;
using System.Text.Json;
using AutoFixture;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Newtonsoft.Json;
using Nox.Lib;

namespace Nox.ClientApi.Tests.Tests
{
    public abstract class NoxIntgrationTestBase : IClassFixture<NoxTestApplicationFactory<StartupFixture>>
    {
        private readonly NoxTestApplicationFactory<StartupFixture> _factory;
        protected readonly Fixture _objectFixture = new();

        protected NoxIntgrationTestBase(NoxTestApplicationFactory<StartupFixture> factory)
        {
            _factory = factory;
        }

        protected async Task<TResult?> GetAsync<TResult>(string requertUrl)
        {
            using var httpClient = _factory.CreateClient();

            var result = await httpClient.GetAsync(requertUrl);
            result.EnsureSuccessStatusCode();
            var data = await result.Content.ReadFromJsonAsync<TResult>();

            return data;
        }

        protected async Task<HttpResponseMessage> GetAsync(string requertUrl)
        {
            using var httpClient = _factory.CreateClient();
            var result = await httpClient.GetAsync(requertUrl);

            return result;
        }

        protected async Task<HttpResponseMessage> PostAsync<TValue>(string requertUrl, TValue data)
        {
            using var httpClient = _factory.CreateClient();

            var result = await httpClient.PostAsJsonAsync(requertUrl, data);

            return result;
        }

        protected async Task<TResult?> PostAsync<TValue, TResult>(string requertUrl, TValue data)
        {
            using var httpClient = _factory.CreateClient();

            var message = await httpClient.PostAsJsonAsync(requertUrl, data);
            message.EnsureSuccessStatusCode();

            var result = await message.Content.ReadFromJsonAsync<TResult>();
            return result;
        }

        protected async Task PutAsync<TValue>(string requertUrl, TValue data)
        {
            using var httpClient = _factory.CreateClient();

            var message = await httpClient.PutAsJsonAsync(requertUrl, data);
            message.EnsureSuccessStatusCode();
        }

        protected async Task PatchAsync<TValue>(string requertUrl, TValue delta)
            where TValue : class
        {
            using var httpClient = _factory.CreateClient();

            var request = await httpClient.PatchAsJsonAsync(requertUrl, delta);
            request.EnsureSuccessStatusCode();
        }

        protected async Task DeleteAsync(string requertUrl)
        {
            using var httpClient = _factory.CreateClient();

            var message = await httpClient.DeleteAsync(requertUrl);
            message.EnsureSuccessStatusCode();
        }
    }

    public class MyValue<TValue>
    {
        [JsonProperty("@odata.type")]
        public TValue Entity { set; get; } = default!;
    }
}