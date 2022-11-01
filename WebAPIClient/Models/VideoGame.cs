using System.Text.Json.Serialization;

namespace WebAPIClient.Models
{
    public class VideoGame
    {
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        [JsonPropertyName("StudioId")]
        public int StudioId { get; set; }

        [JsonPropertyName("MainCharacterId")]
        public int MainCharacterId { get; set; }

        public VideoGame()
        {
            return;
        }

        public VideoGame(int id, string? title, int studioId, int mainCharacterId)
        {
            Id = id;
            Title = title;
            StudioId = studioId;
            MainCharacterId = mainCharacterId;
        }
    }
}