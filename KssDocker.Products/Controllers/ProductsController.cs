using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KssDocker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KssDocker.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsContext _productsContext;

        public ProductsController(ProductsContext productsContext)
        {
            _productsContext = productsContext;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            List<Product> products = await _productsContext.Products.ToListAsync();
            if (products == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product productById =  await _productsContext.Products.SingleOrDefaultAsync(product => product.Id == id);
            if (productById == null)
                return NotFound();

            return productById;
        }
    }
}
