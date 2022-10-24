using WebMVC_API_Client.Helpers;
using WebMVC_API_Client.Models;
using WebMVC_API_Client.Services.Interfaces;

namespace WebMVC_API_Client.Services
{
    public class VideoGameService : IVideoGameService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/VideoGames/";

        public VideoGameService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<VideoGame>> FindAll()
        {
            var responseGet = await _client.GetAsync(BasePath);

            var response = await responseGet.ReadContentAsync<List<VideoGame>>();

            return response;
        }

        public async Task<VideoGame> FindOne(int id)
        {
            var request = BasePath + id.ToString();
            var responseGet = await _client.GetAsync(request);

            var response = await responseGet.ReadContentAsync<VideoGame>();

            var videoGame = new VideoGame(response.Id, response.Title, response.StudioId, response.MainCharacterId);

            return videoGame;
        }
    }
}
