using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebAPIClient.Models;

namespace WebAPIClient.Test
{
    public class TestPOST
    {
        private static readonly HttpClient client = new HttpClient();

        [Fact]
        public async void API_Post()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");

            var requestUri = "https://localhost:7256/api/VideoGames/";

            var videoGamePOST = new VideoGame { Id = null, Title = "Four Score and Seven Years Ago ...", StudioId = 55, MainCharacterId = 55 };
            var resultPOST = await client.PostAsync<VideoGame>(requestUri, videoGamePOST, new JsonMediaTypeFormatter());

            Assert.Equal((double)201, (double)resultPOST.StatusCode);
        }

    }
}