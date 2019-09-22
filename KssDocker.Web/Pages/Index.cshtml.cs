using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using KssDocker.Models;
using KssDocker.Web.HttpClients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KssDocker.Web.Pages
{
    public class IndexModel : PageModel
    {
        private const string ShoppingCartId = "ShoppingCartId";

        private readonly ProductsService _productsService;
        private readonly ShoppingCartService _shoppingCartService;

        [BindProperty]
        public List<Product> Products { get; set; }

        [BindProperty]
        public ShoppingCart ShoppingCart { get; set; }

        public IndexModel(ProductsService productsService, ShoppingCartService shoppingCartService)
        {
            _productsService = productsService;
            _shoppingCartService = shoppingCartService;
        }

        public async Task OnGet()
        {
            Products = await _productsService.GetProducts();
            ShoppingCart = await _shoppingCartService.GetShoppingCart(GetShoppingCartId());
        }

        public async Task<IActionResult> OnPost()
        {
            string productId = Request.Form["product"];
            await _shoppingCartService.AddProductToShoppingCart(GetShoppingCartId(), await _productsService.GetProduct(productId));
            return new RedirectToPageResult("Index");
        }

        private string GetShoppingCartId()
        {            
            if (Request.Cookies[ShoppingCartId] != null)
                return Request.Cookies[ShoppingCartId];

            string result = Guid.NewGuid().ToString("N");
            Response.Cookies.Append(ShoppingCartId, result);

            return result;
        }
    }
}
