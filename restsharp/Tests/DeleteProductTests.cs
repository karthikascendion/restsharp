using NUnit.Framework;
using RestSharp;

namespace restsharp.Tests
{
    public class DeleteProductTests
    {
        private const string BaseUrl = "https://fakestoreapi.com";

        [Test]
        public void DELETE_Product_Should_Return_200()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("/products/1", Method.Delete);

            var response = client.Execute(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));
        }
    }
}
