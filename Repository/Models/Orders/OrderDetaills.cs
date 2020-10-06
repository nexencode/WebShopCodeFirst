using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Repository.GenericRepository;
using Repository.Models.Products;

namespace Repository.Models.Orders
{
    public class OrderDetaills
    {
        private IGenericRepository<OrderDetaills> _repository;

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

        #region Constructors
        public OrderDetaills()
        {
            this._repository = new GenericRepositort<OrderDetaills>();

        }

        public OrderDetaills(IGenericRepository<OrderDetaills> _repository)
        {
            this._repository = _repository;
        }
        #endregion

        public IEnumerable<OrderDetaills> GetAllOrderDetaills()
        {
            return _repository.GetAll();
        }

        public OrderDetaills GetOrderById(int id)
        {
            return _repository.GetById(id);
        }

        public bool SaveOrderDetail(OrderDetaills orderDetaills)
        {
            try
            {
                _repository.Insert(orderDetaills);
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