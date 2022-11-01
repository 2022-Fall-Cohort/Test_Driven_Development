using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebAPIClient.Models;

namespace WebAPIClient.Test
{
    public class TestPUT
    {
        [Fact]
        public async void API_Put()
        {
            var resultPUT = await Program.ClientPUT();

            Assert.Equal((double)204, (double)resultPUT.StatusCode);
        }

    }
}