using WebMVC_API_Client.Models;

namespace WebMVC_API_Client.Services.Interfaces
{
    public interface IVideoGameService
    {
        Task<IEnumerable<VideoGame>> FindAll();

        Task<VideoGame> FindOne(int id);
    }
}
