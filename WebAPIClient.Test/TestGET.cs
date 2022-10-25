using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebAPIClient.Models;
using WebAPIClient;

namespace WebAPIClient.Test
{
    public class TestGET
    {
        private static readonly HttpClient client = new HttpClient();

        [Fact]
        public async void API_Get()
        {
            var msg = await Program.ClientGET();

            Assert.NotNull(msg);
        }

    }
}