Please refer to the repository project called "Test_Driven_Development" at:
https://github.com/2022-Fall-Cohort/Test_Driven_Development

The project folder called "WebMVC_API_Client" contains the example for this project.

Steps to create this project:

1 - Create: ASP.NET Core Web App (Model-View-Controller)

2 - Add your Model Class from your API project.
    Your model class must include a constructor with no arguments and a constructor with all
    properties as arguments.

3 - Add a new controller:
	a - MVC Controller with views, using Entity Framework
	b - Model class: Use the Model Class you created from step # 2 above
	c - Data context class: Press the "+" button and let this class be automatically created.

4 - When the new controller is created, you will also have all of the Views as well:
	- Create.cshtml
	- Delete.cshtml
	- Details.cshtml
	- Edit.cshtml
	- Index.cshtml

5 - Install the following library, using the Nuget Package Manager: Microsoft.AspNet.WebApi.Client

6 - Create a folder called "Helpers" at the same level as the Models folder.
    Add a class called "HttpClientExtensions" and replace the code within it, with the following code:

using System.Text.Json;

namespace WebMVC_API_Client.Helpers
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode == false)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var result = JsonSerializer.Deserialize<T>(
                dataAsString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return result;
        }
    }
}

7 - Create a folder called "Services" at the same level as the Models folder.
    Add a class in this folder, name it like I had named mine "VideoGameService", using your API model name.
    Replace the boilerplate code within it, with the following code, but please remember to change the model
    name from "VideoGame" to whatever your model name is. Also, your project name may be different in the "using"
    statements.

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

8 - Within the Services folder, create another folder called "Interfaces".
    Add a "New Item" to this Interfaces folder. When the screen comes up for what type of item, choose Interface.
    Name the Interface like this: IVideoGameService.cs
    Just like before, changing the "VideoGame" to whatever your model is called.
    Please replace the boilerplate code with the following, and once again, replace "VideoGame" with the name of
    your API model.

using WebMVC_API_Client.Models;

namespace WebMVC_API_Client.Services.Interfaces
{
    public interface IVideoGameService
    {
        Task<IEnumerable<VideoGame>> FindAll();

        Task<VideoGame> FindOne(int id);
    }
}

9 - Use the following code for your Program.cs (Again, don't forget to make adjustments for model name and project name):

using WebMVC_API_Client.Services;
using WebMVC_API_Client.Services.Interfaces;

namespace WebMVC_API_Client
{
    public class Program
    {
        public static ServiceDescriptor? videoGame { get; private set; }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient<IVideoGameService, VideoGameService>(c =>
            c.BaseAddress = new Uri("https://localhost:7256/"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

    Also, check the launchSettings.json. The url and port number should be as follows:
          "applicationUrl": "https://localhost:7135",


10 - Finally, we have the controller. There are very significant changes here.
     Please use the following code and once again, make the apporpriate changes for the name of your model and
     project and the port number and ALSO, BE SURE your controller is named correctly.
     For example, one problem I experienced is that the new project named the controller
     in the plural "VideoGamesController" and NOT "VideoGameController". So I had to fix it
     within the following code after I pasted it in:

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
        private IVideoGameService? _service;

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

        // Example: https://localhost:7256/api/VideoGames
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




























