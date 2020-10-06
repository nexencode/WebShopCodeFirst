using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.GenericRepository;
using Repository.Models.Users;

namespace Repository.Models.Orders
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Delivered
    }
    public class Order
    {
        private IGenericRepository<Order> _repository;
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int CurrancyId { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShipAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public Currancy Currancy { get; set; }
        public User User { get; set; }



        #region Constructors
        public Order()
        {
            this._repository = new GenericRepositort<Order>();

        }

        public Order(IGenericRepository<Order> _repository)
        {
            this._repository = _repository;
        }
        #endregion


        public IEnumerable<Order> GetAllOrders()
        {
            return _repository.GetAll();
        }

        public Order GetOrderById(int id)
        {
            return _repository.GetById(id);
        }

        public bool SaveOrder(Order order)
        {
            try
            {
                _repository.Insert(order);
                _repository.Save();
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }
    }

    


}