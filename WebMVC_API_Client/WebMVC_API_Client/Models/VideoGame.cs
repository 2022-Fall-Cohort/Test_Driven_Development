namespace WebMVC_API_Client.Models
{
    public class VideoGame
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public int StudioId { get; set; }
        public int MainCharacterId { get; set; }

        public VideoGame(int? id, string? title, int studioId, int mainCharacterId)
        {
            Id = id;
            Title = title;
            StudioId = studioId;
            MainCharacterId = mainCharacterId;
        }

        public VideoGame()
        {
            return;
        }

        internal class ToListAsync : Task<string?>
        {
            public ToListAsync(Func<string?> function) : base(function)
            {
            }
        }

        public static explicit operator VideoGame(List<VideoGame> v)
        {
            throw new NotImplementedException();
        }
    }
}
