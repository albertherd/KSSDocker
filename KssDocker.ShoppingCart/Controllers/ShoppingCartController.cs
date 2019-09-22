using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KssDocker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace KssDocker.ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private const string ShoppingCartKey = "ShoppingCart";
        private readonly ConnectionMultiplexer _redis;

        public ShoppingCartController(ConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        // GET: api/ShoppingCart/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Models.ShoppingCart>> Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            IDatabase db = _redis.GetDatabase();
            RedisValue cart = await db.StringGetAsync(id);

            if (cart.IsNullOrEmpty)
                return Ok(new Models.ShoppingCart() { Id = id });

            return JsonConvert.DeserializeObject<Models.ShoppingCart>(cart);
        }

        // POST: api/ShoppingCart
        [HttpPost]
        public void Post(Models.ShoppingCart cart)
        {
            IDatabase db = _redis.GetDatabase();
            db.StringSetAsync(cart.Id, JsonConvert.SerializeObject(cart));
        }
    }
}
