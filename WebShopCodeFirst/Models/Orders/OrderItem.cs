using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopCodeFirst.Models.Products;

namespace WebShopCodeFirst.Models.Orders
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}