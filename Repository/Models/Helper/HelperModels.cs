using Repository.Models.Products;
using Repository.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Helper
{
    public class HelperModels
    {
        public HelperModels()
        {

        }
        public User User { get; set; }
        public Address Address { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
