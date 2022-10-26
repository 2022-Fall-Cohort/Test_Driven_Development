using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebAPIClient.Models;

namespace WebAPIClient.Test
{
    public class TestPOST
    {
        [Fact]
        public async void API_Post()
        {
            var resultPOST = await Program.ClientPOST();

            Assert.Equal((double)201, (double)resultPOST.StatusCode);
        }

    }
}