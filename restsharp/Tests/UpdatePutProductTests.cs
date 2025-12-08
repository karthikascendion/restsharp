using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using ProductAPI_Testing.Models;

namespace restsharp.Tests
{
    public class UpdatePutProductTests
    {
        private const string BaseUrl = "https://fakestoreapi.com";

        [Test]
        public void PUT_Product_Should_Update_All_Fields()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("/products/1", Method.Put);

            request.AddJsonBody(new
            {
                title = "Updated Product",
                price = 150.50,
                description = "Updated description",
                image = "https://example.com/updated.jpg",
                category = "fashion"
            });

            var response = client.Execute(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var product = JsonConvert.DeserializeObject<Product>(response.Content);

            Assert.That(product.title, Is.EqualTo("Updated Product"));
        }
    }
}
