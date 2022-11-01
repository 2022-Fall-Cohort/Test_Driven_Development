using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebMVC_API_Client.Models;
using WebMVC_API_Client.Services.Interfaces;

namespace WebMVC_API_Client.Controllers
{
    public class VideoGameController : Controller
    {
        private IVideoGameService _service;

        private static readonly HttpClient client = new HttpClient();

        private string requestUri = "https://localhost:7256/api/VideoGames/";

        public VideoGameController(IVideoGameService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.FindAll();

            return View(response);
        }

        // GET: VideoGame/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var videoGame = await _service.FindOne(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            return View(videoGame);
        }

        // GET: VideoGame/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoGame/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,StudioId,MainCharacterId")] VideoGame videoGame)
        {
            videoGame.Id = null;
            var resultPost = await client.PostAsync<VideoGame>(requestUri, videoGame, new JsonMediaTypeFormatter());

            return RedirectToAction(nameof(Index));
        }

        // GET: VideoGame/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var videoGame = await _service.FindOne(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            return View(videoGame);
        }

        // POST: VideoGame/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,StudioId, MainCharacterId")] VideoGame videoGame)
        {
            if (id != videoGame.Id)
            {
                return NotFound();
            }

            var resultPut = await client.PutAsync<VideoGame>(requestUri + videoGame.Id.ToString(), videoGame, new JsonMediaTypeFormatter());
            return RedirectToAction(nameof(Index));
        }

        // GET: VideoGame/Delete/5
        public async Task<IActionResult> Delete(int id)

        {
            var videoGame = await _service.FindOne(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            return View(videoGame);
        }

        // POST: VideoGame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultDelete = await client.DeleteAsync(requestUri + id.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}
