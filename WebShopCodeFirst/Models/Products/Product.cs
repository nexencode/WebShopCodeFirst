using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopCodeFirst.Models.Products
{
    public class Product
    {

        #region Fields and Properties
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool HaveDiscount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDigital { get; set; }
        public bool IsService { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion


    }
}