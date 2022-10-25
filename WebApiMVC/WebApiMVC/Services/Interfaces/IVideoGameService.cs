using WebApiMVC.Models;

namespace WebApiMVC.Services.Interfaces
{
    public interface IVideoGameService
    {
        Task<IEnumerable<VideoGame>> FindAll();

        Task<VideoGame> FindOne(int id);
    }
}
