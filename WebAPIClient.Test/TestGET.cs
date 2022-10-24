using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebAPIClient.Models;

namespace WebAPIClient.Test
{
    public class TestGET
    {
        private static readonly HttpClient client = new HttpClient();

        [Fact]
        public async void API_Get()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");

            var requestUri = "https://localhost:7256/api/VideoGames/";

            var stringTask = client.GetStringAsync(requestUri);
            var msg = await stringTask;

            Assert.NotNull(msg);
        }

    }
}