using MassTransit;
using System.Net.Http;

namespace Cryptocash.Ui.Generated.Data.Generic
{
    /// <summary>
    /// Service class to enable access to target Api results
    /// </summary>
    public static class ApiDataService
    {
        /// <summary>
        /// Service method to read target Api and return results as Json string
        /// </summary>
        /// <param name="ApiUiService"></param>
        /// <returns>Task<string>(Json)</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task<string> ReadApi(ApiUiService? ApiUiService)
        {
            if (ApiUiService == null || string.IsNullOrWhiteSpace(ApiUiService.Url))
            {
                throw new ArgumentException("ApiService.ReadApi: Malformed Input", nameof(ApiUiService));
            }

            var Client = new HttpClient();

            var HttpResponseMessage = await Client.GetAsync(ApiUiService.ApiGetQuery);

            if (HttpResponseMessage.IsSuccessStatusCode)
            {
                var ResponseContent = await HttpResponseMessage.Content.ReadAsStringAsync();

                return ResponseContent;
            }
            else
            {
                var ErrorResponseContent = await HttpResponseMessage.Content.ReadAsStringAsync();
                throw new Exception($"ApiService.ReadApi: HttpResponseMessage Error: {HttpResponseMessage.StatusCode}: {ErrorResponseContent}");
            }
        }

        /// <summary>
        /// Service method to delete entity in target Api
        /// </summary>
        /// <param name="ApiUiService"></param>
        /// <param name=""></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task DeleteApi(ApiUiService? ApiUiService)
        {
            if (ApiUiService == null || string.IsNullOrWhiteSpace(ApiUiService.Url))
            {
                throw new ArgumentException("ApiService.DeleteApi: Malformed Input", nameof(ApiUiService));
            }
            
            if(ApiUiService.ApiDeleteEtag == null)
            {
                throw new ArgumentException("ApiService.DeleteApi: Malformed Etag", nameof(ApiUiService));
            }

            var Client = new HttpClient();

            var headers = CreateEtagHeader(ApiUiService.ApiDeleteEtag);

            foreach (var header in headers)
            {
                Client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            var HttpResponseMessage = await Client.DeleteAsync(ApiUiService.ApiDeleteQuery);

            if (!HttpResponseMessage.IsSuccessStatusCode)
            {
                var ErrorResponseContent = await HttpResponseMessage.Content.ReadAsStringAsync();
                throw new Exception($"ApiService.ReadApi: HttpResponseMessage Error: {HttpResponseMessage.StatusCode}: {ErrorResponseContent}");
            }
        }

        /// <summary>
        /// Method to create Etag headers for Api call
        /// </summary>
        /// <param name="etag"></param>
        /// <returns></returns>
        public static Dictionary<string, IEnumerable<string>> CreateEtagHeader(System.Guid? etag)
        => new()
        {
                { "If-Match", new List<string> { $"\"{etag}\"" } }
        };
    }
}