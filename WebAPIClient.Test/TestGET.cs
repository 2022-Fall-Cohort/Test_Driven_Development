using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebAPIClient.Models;

namespace WebAPIClient.Test
{
    public class TestGET
    {
        [Fact]
        public async void API_Get()
        {
            var msg = await Program.ClientGET();

            Assert.NotNull(msg);
        }

    }
}