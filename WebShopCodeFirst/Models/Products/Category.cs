using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopCodeFirst.Models.Products
{
    public class Category
    {
        #region Fields and Properties
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
        public bool IsActive { get; set; } 
        #endregion
    }
}