using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Repository.Models.Orders;
using Repository.Models.Products;
using Repository.Models.Users;

namespace Repository.Context
{
    public class WebShopDbContext : DbContext
    {
        public WebShopDbContext() : base("WebShopDB")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Repository.Models.Users.Action> Actions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductLocation> ProductLocations { get; set; }
        public DbSet<Licence> Licences { get; set; }
        public DbSet<Currancy> Currancies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetaills> OrderDetaills { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}