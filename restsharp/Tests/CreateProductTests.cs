using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using ProductAPI_Testing.Models;

namespace restsharp.Tests
{
    public class CreateProductTests
    {
        private const string BaseUrl = "https://fakestoreapi.com";

        [Test]
        public void POST_Product_Should_Create_And_Return_Product()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("/products", Method.Post);

            request.AddJsonBody(new
            {
                title = "New Test Product",
                price = 99.99,
                description = "Test description",
                image = "https://example.com/test.jpg",
                category = "electronics"
            });

            var response = client.Execute(request);

            Assert.That(new[] { 200, 201 }, Does.Contain((int)response.StatusCode));

            var product = JsonConvert.DeserializeObject<Product>(response.Content);

            Assert.That(product.title, Is.EqualTo("New Test Product"));
        }
    }
}