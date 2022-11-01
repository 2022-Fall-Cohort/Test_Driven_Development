namespace API_Workshop.Models
{
    public class VideoGame
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int StudioId { get; set; }
        public int MainCharacterId { get; set; }

    }
}
