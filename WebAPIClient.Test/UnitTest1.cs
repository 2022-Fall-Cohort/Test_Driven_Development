using System.Net.Http.Headers;

namespace WebAPIClient.Test
{
    public class UnitTest1
    {
        private static readonly HttpClient client = new HttpClient();

        [Fact]
        public void Test1()
        {
            Assert.True(false);
        }

        [Fact]
        public async void API_Get()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");

            var requestUri = "https://localhost:7256/api/VideoGames/X";

            var stringTask = client.GetStringAsync(requestUri);
            var msg = await stringTask;

            Assert.NotNull(msg);
        }

    }
}