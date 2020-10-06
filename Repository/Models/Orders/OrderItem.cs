using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Models.Products;

namespace Repository.Models.Orders
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        // public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}