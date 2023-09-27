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
    }
}