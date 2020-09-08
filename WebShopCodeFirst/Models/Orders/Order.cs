using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopCodeFirst.Models.Users;

namespace WebShopCodeFirst.Models.Orders
{
    public enum OrderStatus
    {
        Pending,
        Delivered
    }
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int CurrancyId { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShipAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public Currancy Currancy { get; set; }
        public User User { get; set; }
    }
}