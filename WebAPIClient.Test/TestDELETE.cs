using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebAPIClient.Models;

namespace WebAPIClient.Test
{
    public class TestDELETE
    {
        private static readonly HttpClient client = new HttpClient();

        [Fact]
        public async void API_Delete()
        {
            var resultDELETE = await Program.ClientDELETE();

            Assert.Equal((double)204, (double)resultDELETE.StatusCode);
        }

    }
}