using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopCodeFirst.Models.Users;

namespace WebShopCodeFirst.Models.Products
{
    public class Warehouse
    {
        #region Fields and Properties
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public bool IsActive { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        #endregion
    }
}