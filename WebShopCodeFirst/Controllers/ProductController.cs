using Repository.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShopCodeFirst.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private Product _product = new Product();

        public ActionResult Index()
        {
            IEnumerable<Product> model = _product.GetAllProducts();
            return View(model);
        }
        public ActionResult CustomerIndex()
        {
            IEnumerable<Product> model = _product.GetAllProducts();
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product model)
        {
            bool isSuccess = _product.AddNewProduct(model);
            if (isSuccess)
            {
                return RedirectToAction("Products");
            }
            else
            {
                return View();
            }
        }

        //!!!PITANJE
        [HttpGet]
        public ActionResult DeleteProduct(int ProductId)
        {
            bool isSuccess = _product.DeleteProduct(ProductId);
            return RedirectToAction("Products");
        }

        [HttpGet]
        public ActionResult EditProduct(int ProductId)
        {
            Product model = _product.GetProductById(ProductId);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            bool success = _product.EditProduct(product);
            return RedirectToAction("Products");
        }
    }
}