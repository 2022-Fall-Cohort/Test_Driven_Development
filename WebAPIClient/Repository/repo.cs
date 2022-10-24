using System;
using System.Text.Json.Serialization;

namespace WebAPIClient.Repository
{
    public class Repository
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        [JsonPropertyName("StudioId")]
        public int StudioId { get; set; }

        [JsonPropertyName("MainCharacterId")]
        public int MainCharacterId { get; set; }

    }
}