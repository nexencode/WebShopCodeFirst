using Repository.Models.Products;
using Repository.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShopCodeFirst.Controllers
{
    public class AdminController : Controller
    {
        private User _user = new User();
        private Role _role = new Role();
        private Product _product = new Product();
        private Category _category = new Category();

        //Da li ovde kreiram POST, PUT, DELETE, UPTDARE
        // GET: Admin
        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var categories = _category.GetAllCategories();
            foreach (var item in categories)
            {
                list.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryDescription });
            }
            return list;
        }
        public List<SelectListItem> GetRoles()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var roles = _role.GetAllRoles();
            foreach (var item in roles)
            {
                list.Add(new SelectListItem { Value = item.RoleId.ToString(), Text = item.RoleName });
            }
            return list;
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        #region Users Actions
        public ActionResult Users()
        {
            IEnumerable<User> model = _user.GetAllUsers();
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            ViewBag.RoleList = GetRoles();
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User model)
        {
            bool isSuccess = _user.AddNewUser(model);
            if (isSuccess)
            {
                if (Session["Users"] != null)
                {
                    var Users = Session["Users"] as List<User>;
                    Users.Add(model);
                    Session["Users"] = Users;
                }
                else
                {
                    var Users = new List<User>();
                    Users.Add(model);
                    Session["Users"] = Users;
                }

                return RedirectToAction("Users");
            }
            else
            {
                return View("Dashboard");
            }

        }

        [HttpGet]
        public ActionResult DeleteUser(int UserId)
        {
            bool isSuccess = _user.DeleteUser(UserId);
            return RedirectToAction("Users");
        }

        [HttpGet]
        public ActionResult EditUser(int UserId)
        {
            ViewBag.RoleList = GetRoles();
            User model = _user.GetUserById(UserId);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            bool isSuccess = _user.EditUser(user);
            if (isSuccess)
            {
                return RedirectToAction("Users");
            }
            else
            {
                return View("Dashboard");
            }
        }
        #endregion Actions

        #region Products Actions
        public ActionResult Products()
        {
            var model = _product.GetAllProducts();
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product model, HttpPostedFileBase file)
        {
            string imgSrc = null;
            if (file != null)
            {
                imgSrc = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/Img/"), imgSrc);
                file.SaveAs(path);
            }
            model.ImageUrl = imgSrc;
            //model.CreatedDate = DateTime.Now;
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

        [HttpGet]
        public ActionResult DeleteProduct(int ProductId)
        {
            bool isSuccess = _product.DeleteProduct(ProductId);
            return RedirectToAction("Products");
        }

        [HttpGet]
        public ActionResult EditProduct(int ProductId)
        {
            ViewBag.CategoryList = GetCategory();
            Product model = _product.GetProductById(ProductId);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product, HttpPostedFileBase file)
        {
            string imgSrc = null;
            if (file != null)
            {
                imgSrc = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/Img/"), imgSrc);
                file.SaveAs(path);
            }

            product.ImageUrl = imgSrc != null ? imgSrc : product.ImageUrl;
            bool success = _product.EditProduct(product);
            return RedirectToAction("Products");
        }
        #endregion


    }
}