using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KssDocker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KssDocker.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private const string ProductsDb = "productsdb.txt";

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            List<Product> products = await GetAllProducts();
            if (products == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            List<Product> products = await GetAllProducts();
            if (products == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            foreach (Product product in products)
            {
                if (product.Id == id)
                    return product;
            }

            return NotFound();
        }

        private async Task<List<Product>> GetAllProducts()
        {
            string productsDbFullPath = AppContext.BaseDirectory + ProductsDb;
            System.IO.FileInfo fi = new System.IO.FileInfo(productsDbFullPath);
            if (!fi.Exists)
                return null;

            string productsFileContents = await System.IO.File.ReadAllTextAsync(productsDbFullPath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(productsFileContents);
        }
    }
}
