using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models.Products
{
    public class Product
    {
        #region Fields and Properties
        private IGenericRepository<Product> _repository;

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

        public string ImageUrl { get; set; }
        #endregion

        #region Constructors
        public Product()
        {
            this._repository = new GenericRepositort<Product>();

        }

        public Product(IGenericRepository<Product> _repository)
        {
            this._repository = _repository;
        }

        public Product(string productName, string productDescription, decimal price, int quantity, bool haveDiscount, bool isActive, bool isDigital, bool isService, int categoryId)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            Price = price;
            Quantity = quantity;
            HaveDiscount = haveDiscount;
            IsActive = isActive;
            IsDigital = isDigital;
            IsService = isService;
            CategoryId = categoryId;
        }
        #endregion

        #region Methods

        //public void PrintProduct()
        //{
        //    Console.WriteLine($"ID: {ProductId}, Name: {FirstName}, Productame: {Productname}, Email: {Email}, Age: {Age}");
        //    Console.WriteLine($"-------------------------");
        //}

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _repository.GetById(id);
        }

        public bool AddNewProduct(Product product)
        {
            try
            {
                _repository.Insert(product);
                _repository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditProduct(Product product)
        {
            try
            {
                _repository.Update(product);
                _repository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(int ProductId)
        {
            try
            {
                Product Product = _repository.GetById(ProductId);
                _repository.Delete(Product);
                _repository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        #endregion
    }
}