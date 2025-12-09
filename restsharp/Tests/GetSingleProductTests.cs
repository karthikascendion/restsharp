using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using restsharp_api.Models;

namespace restsharp_api.Tests
{
    public class GetSingleProductTests
    {
        private const string BaseUrl = "https://fakestoreapi.com";

        [Test]
        public void GET_Product_By_Id_Should_Return_Product()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("/products/1", Method.Get);

            var response = client.Execute(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var product = JsonConvert.DeserializeObject<Product>(response.Content);

            Assert.That(product.id, Is.EqualTo(1));
        }
    }
}