using Repository.Context;
using Repository.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShopCodeFirst.Controllers
{
    public class LoginController : Controller
    {
        User _user = new User();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginLogic(User userModel)
        {
            using (WebShopDbContext context = new WebShopDbContext())
            {
                User user = context.Users.Where(u => u.Username == userModel.Username && u.Password == userModel.Password).FirstOrDefault();

                if (user != null)
                {
                    switch (user.RoleId)
                    {
                        case 1:
                            Session["UserId"] = user.UserId;
                            return RedirectToAction("Dashboard", "Admin");
                        case 4:
                            Session["UserId"] = user.UserId;
                            return RedirectToAction("Shop", "User");
                        default:
                            return View("Index", user);
                    }
                }
                else
                {
                    //userModel.ErrorLoginMessage = "Incorect Login data";
                    return View("Index", user);
                }
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}