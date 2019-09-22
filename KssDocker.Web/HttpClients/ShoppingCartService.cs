using KssDocker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KssDocker.Web.HttpClients
{
    public class ShoppingCartService
    {
        private readonly HttpClient _httpClient;

        public ShoppingCartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ShoppingCart> GetShoppingCart(string cartId)
        {
            return JsonConvert.DeserializeObject<ShoppingCart>(await _httpClient.GetStringAsync($"{cartId}"));
        }

        public async Task AddProductToShoppingCart(string cartId, Product product)
        {
            ShoppingCart cart = await GetShoppingCart(cartId);
            cart.Products.Add(product);
            await _httpClient.PostAsJsonAsync(string.Empty, cart);
        }
    }
}
