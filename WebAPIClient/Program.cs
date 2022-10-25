using WebAPIClient.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace WebAPIClient
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var msg = await ClientGET();
            Console.WriteLine(JToken.Parse(msg).ToString());

            var resultPOST = await ClientPOST();
            Console.WriteLine(resultPOST);

            var resultPUT = await ClientPUT();
            Console.WriteLine(resultPUT);

            var resultDELETE = await ClientDELETE();
            Console.WriteLine(resultDELETE);

        }

        public class Header : HttpClient
        {
            public string requestUri { get; set; }
            public HttpClient client { get; set; }

            public Header()
            {
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");

                requestUri = "https://localhost:7256/api/VideoGames/";
            }
        }


        public static async Task<string> ClientGET()
        {

            Header client = new Header();
            var requestUri = client.requestUri;

            Console.WriteLine(requestUri);

            var stringTask = client.GetStringAsync(requestUri);
            var msg = await stringTask;

            return msg;

        }

        public static async Task<HttpResponseMessage> ClientPOST()
        {
            Header client = new Header();
            var requestUri = client.requestUri;

            var videoGamePOST = new VideoGame { Title = "Four Score and Seven Years Ago ...", StudioId = 55, MainCharacterId = 55 };

            var resultPOST = await client.PostAsync<VideoGame>(requestUri, videoGamePOST, new JsonMediaTypeFormatter());

            return (HttpResponseMessage)resultPOST;

        }

        public static async Task<HttpResponseMessage> ClientPUT()
        {
            Header client = new Header();
            var requestUri = client.requestUri;

            var repositoryPUT = new VideoGame { Id = 11, Title = "WE THE PEOPLE of the United States of America ...", StudioId = 55, MainCharacterId = 55 };
            var resultPUT = await client.PutAsync<VideoGame>(requestUri + "11", repositoryPUT, new JsonMediaTypeFormatter());

            return (HttpResponseMessage)resultPUT;

        }

        public static async Task<HttpResponseMessage> ClientDELETE()
        {
            Header client = new Header();
            var requestUri = client.requestUri;

            var resultDELETE = await client.DeleteAsync(requestUri + "45");

            return (HttpResponseMessage)resultDELETE;

        }

    }
}