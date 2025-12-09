using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using restsharp_api.Models;

namespace restsharp_api.Tests
{
    public class UpdatePatchProductTests
    {
        private const string BaseUrl = "https://fakestoreapi.com";

        [Test]
        public void PATCH_Product_Should_Update_Price()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("/products/1", Method.Patch);

            request.AddJsonBody(new
            {
                price = 199.99
            });

            var response = client.Execute(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var product = JsonConvert.DeserializeObject<Product>(response.Content);

            Assert.That(product.price, Is.EqualTo(199.99));
        }
    }
}