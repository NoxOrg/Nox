using System.Text;

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
        public static async Task<string> ReadAsyncApi(ApiUiService? ApiUiService)
        {
            if (ApiUiService == null || string.IsNullOrWhiteSpace(ApiUiService.Url))
            {
                throw new ArgumentException("ApiDataService.ReadAsyncApi: Malformed Input", nameof(ApiUiService));
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
                throw new Exception($"ApiDataService.ReadAsyncApi: HttpResponseMessage Error: {HttpResponseMessage.StatusCode}: {ErrorResponseContent}");
            }
        }

        /// <summary>
        /// Service method to send Add Entity data to Api and create new Api Entity
        /// </summary>
        /// <param name="ApiUiService"></param>
        /// <returns>Task</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task PostAsyncApi(ApiUiService? ApiUiService)
        {
            if (ApiUiService == null
                || string.IsNullOrWhiteSpace(ApiUiService.Url)
                || string.IsNullOrWhiteSpace(ApiUiService.ApiCreateData))
            {
                throw new ArgumentException("ApiDataService.PostAsyncApi: Malformed Input", nameof(ApiUiService));
            }
            var Client = new HttpClient();

            var Content = new StringContent(ApiUiService.ApiCreateData.ToString(), Encoding.UTF8, "application/json");

            var HttpResponseMessage = await Client.PostAsync(new Uri(ApiUiService.Url), Content);

            if (!HttpResponseMessage.IsSuccessStatusCode)
            {
                var ErrorResponseContent = await HttpResponseMessage.Content.ReadAsStringAsync();
                throw new Exception($"ApiDataService.PostAsyncApi: HttpResponseMessage Error: {HttpResponseMessage.StatusCode}: {ErrorResponseContent}");
            }
        }

        /// <summary>
        /// Service method to send Edit Entity data to Api and update Api Entity
        /// </summary>
        /// <param name="ApiUiService"></param>
        /// <returns>Task</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task PutAsyncApi(ApiUiService? ApiUiService)
        {
            if (ApiUiService == null
                || string.IsNullOrWhiteSpace(ApiUiService.ApiEditId)
                || string.IsNullOrWhiteSpace(ApiUiService.ApiEditData)
                || string.IsNullOrWhiteSpace(ApiUiService.ApiEditQuery)
                )
            {
                throw new ArgumentException("ApiDataService.PutAsyncApi: Malformed Input", nameof(ApiUiService));
            }

            if (ApiUiService.ApiEditEtag == null)
            {
                throw new ArgumentException("ApiDataService.PutAsyncApi: Malformed Etag", nameof(ApiUiService));
            }

            var Client = new HttpClient();

            var headers = CreateEtagHeader(ApiUiService.ApiEditEtag);

            foreach (var header in headers)
            {
                Client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            var Content = new StringContent(ApiUiService.ApiEditData.ToString(), Encoding.UTF8, "application/json");

            var HttpResponseMessage = await Client.PutAsync(new Uri(ApiUiService.ApiEditQuery), Content);

            if (!HttpResponseMessage.IsSuccessStatusCode)
            {
                var ErrorResponseContent = await HttpResponseMessage.Content.ReadAsStringAsync();
                throw new Exception($"ApiDataService.PutAsyncApi: HttpResponseMessage Error: {HttpResponseMessage.StatusCode}: {ErrorResponseContent}");
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
        public static async Task DeleteAsyncApi(ApiUiService? ApiUiService)
        {
            if (ApiUiService == null || string.IsNullOrWhiteSpace(ApiUiService.Url))
            {
                throw new ArgumentException("ApiDataService.DeleteAsyncApi: Malformed Input", nameof(ApiUiService));
            }
            
            if(ApiUiService.ApiDeleteEtag == null)
            {
                throw new ArgumentException("ApiDataService.DeleteAsyncApi: Malformed Etag", nameof(ApiUiService));
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
                throw new Exception($"ApiDataService.DeleteAsyncApi: HttpResponseMessage Error: {HttpResponseMessage.StatusCode}: {ErrorResponseContent}");
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