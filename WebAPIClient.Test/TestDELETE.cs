using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebAPIClient.Models;

namespace WebAPIClient.Test
{
    public class TestDELETE
    {
        private static readonly HttpClient client = new HttpClient();

        [Fact]
        public async void API_Delete()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");

            var requestUri = "https://localhost:7256/api/VideoGames/";

            var resultDELETE = await client.DeleteAsync(requestUri + "31");

            Assert.Equal((double)204, (double)resultDELETE.StatusCode);
        }

    }
}