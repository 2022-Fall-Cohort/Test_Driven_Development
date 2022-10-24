using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebAPIClient.Models;

namespace WebAPIClient.Test
{
    public class TestPUT
    {
        private static readonly HttpClient client = new HttpClient();

        [Fact]
        public async void API_Put()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");

            var requestUri = "https://localhost:7256/api/VideoGames/";

            var videoGamePUT = new VideoGame { Id = 11, Title = "WE THE PEOPLE of the United States of America ...", StudioId = 55, MainCharacterId = 55 };
            var resultPUT = await client.PutAsync<VideoGame>(requestUri + "11", videoGamePUT, new JsonMediaTypeFormatter());

            Assert.Equal((double)204, (double)resultPUT.StatusCode);
        }

    }
}