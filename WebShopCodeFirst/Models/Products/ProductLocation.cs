using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShopCodeFirst.Models.Products
{
    public class ProductLocation
    {
        [Key, Column(Order = 1)]
        public int WarehouseId { get; set; }
        [Key, Column(Order = 2)]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Warehouse Warehouse { get; set; }
        public Product Product { get; set; }
    }
}