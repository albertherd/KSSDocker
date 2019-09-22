using System;
using System.Collections.Generic;
using System.Text;

namespace KssDocker.Models
{
    public class ShoppingCart
    {
        public string Id { get; set; }
        public List<Product> Products { get; set; }

        public ShoppingCart()
        {
            Products = new List<Product>();
        }
    }
}
