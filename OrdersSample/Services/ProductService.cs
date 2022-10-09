using System;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using OrdersSample.Interfaces;
using OrdersSample.Models;

namespace OrdersSample.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:8090/");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Product> Get()
        {
            List<Product> list = null;
            HttpResponseMessage response = _client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadFromJsonAsync<List<Product>>().Result;
            }
            return list;
        }

        public Product GetById(string id)
        {
            Product item = null;
            HttpResponseMessage response = _client.GetAsync($"/product/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadFromJsonAsync<Product>().Result;
            }
            return item;
        }
    }
}

