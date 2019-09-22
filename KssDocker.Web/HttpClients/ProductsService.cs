using KssDocker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KssDocker.Web.HttpClients
{
    public class ProductsService
    {
        private readonly HttpClient _httpClient;

        public ProductsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProducts()
        {
            return JsonConvert.DeserializeObject<List<Product>>(await _httpClient.GetStringAsync(string.Empty));
        }

        public async Task<Product> GetProduct(string id)
        {
            return JsonConvert.DeserializeObject<Product>(await _httpClient.GetStringAsync(id));
        }
    }
}
