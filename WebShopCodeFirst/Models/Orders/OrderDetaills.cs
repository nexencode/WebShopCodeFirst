using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebShopCodeFirst.Models.Products;

namespace WebShopCodeFirst.Models.Orders
{
    public class OrderDetaills
    {
        [Key, Column(Order = 1)]
        public int OrderId { get; set; }
        [Key, Column(Order = 2)]
        public int ProductId { get; set; }
        public int LicanceId { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }

        public Licence Licence { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}