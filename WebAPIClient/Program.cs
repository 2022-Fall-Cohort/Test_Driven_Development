using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using WebAPIClient.Repository;
using Newtonsoft.Json.Linq;

internal class Program
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        await ProcessRepositories();
    }

    private static async Task ProcessRepositories()
    {
        client.DefaultRequestHeaders.Accept.Clear();

        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");

        var requestUri = "https://localhost:7256/api/VideoGames/";

        var stringTask = client.GetStringAsync(requestUri);
        var msg = await stringTask;

        Console.WriteLine("HTTP GET");
        Console.WriteLine(JToken.Parse(msg).ToString());
        Console.WriteLine("=========================================================================================");

        var repositoryPOST = new Repository { Title = "Even Once again, ANOTHER Video Game", StudioId = 88, MainCharacterId = 55 };
        var resultPOST = await client.PostAsync<Repository>(requestUri, repositoryPOST, new JsonMediaTypeFormatter());

        Console.WriteLine("HTTP POST");
        Console.WriteLine(resultPOST);
        Console.WriteLine("=========================================================================================");

        var repositoryPUT = new Repository { Id = 11, Title = "WE THE PEOPLE ...", StudioId = 55, MainCharacterId = 55 };
        var resultPUT = await client.PutAsync<Repository>(requestUri + "11", repositoryPUT, new JsonMediaTypeFormatter());
        
        Console.WriteLine("HTTP PUT");
        Console.WriteLine(resultPUT);
        Console.WriteLine("=========================================================================================");

        var resultDELETE = await client.DeleteAsync(requestUri + "20");

        Console.WriteLine("HTTP DELETE");
        Console.WriteLine(resultDELETE);
        Console.WriteLine("=========================================================================================");


    }
}