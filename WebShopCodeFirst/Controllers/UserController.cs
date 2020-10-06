using Repository.GenericRepository;
using Repository.Models.Helper;
using Repository.Models.Orders;
using Repository.Models.Products;
using Repository.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShopCodeFirst.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private User _user = new User();
        private Role _role = new Role();
        private Product _product = new Product();
        private Category _category = new Category();
        private Order _order = new Order();
        private OrderDetaills _orderDetail = new OrderDetaills();

        public ActionResult Index()
        {
            IEnumerable<User> model = _user.GetAllUsers();


            return View(model);
        }


        public ActionResult Shop()
        {
            HelperModels helperModels = new HelperModels();
            helperModels.Categories = _category.GetAllCategories().ToList();
            helperModels.Products = _product.GetAllProducts().ToList();
            IEnumerable<Product> model = _product.GetAllProducts();

            return View(helperModels);
        }

        public ActionResult ShowItem(int ProductId)
        {
            Product model = _product.GetProductById(ProductId);
            return View(model);
        }

        public ActionResult AddToCart(int ProductId)
        {
            List<CartItem> cart = new List<CartItem>();
            Product product = _product.GetProductById(ProductId);

            if (Session["cart"] == null)
            {
                cart.Add(new CartItem()
                {
                    Product = product,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                cart = (List<CartItem>)Session["cart"];
                var count = cart.Count();
                for (int i = 0; i < count; i++)
                {
                    if (cart[i].Product.ProductId == ProductId)
                    {
                        int prevQuantity = cart[i].Quantity;
                        cart.Remove(cart[i]);
                        cart.Add(new CartItem()
                        {
                            Product = product,
                            Quantity = prevQuantity + 1
                        });
                        break;
                    }
                    else
                    {
                        var prd = cart.Where(x => x.Product.ProductId == ProductId).FirstOrDefault();
                        if (prd == null)
                        {
                            cart.Add(new CartItem()
                            {
                                Product = product,
                                Quantity = 1
                            });
                        }
                    }
                }

                Session["cart"] = cart;
            }

            return RedirectToAction("Shop");
        }


        public ActionResult RemoveFromCart(int ProductId)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Product.ProductId == ProductId)
                {
                    cart.Remove(item);
                    break;
                }
            }

            if (cart.Count == 0)
            {
                Session["cart"] = null;
            }
            else
            {
                Session["cart"] = cart;
            }
            return RedirectToAction("Shop");
        }

        public ActionResult Checkout()
        {
            return View("Checkout");
        }

        public ActionResult RemoveFromCheckoutAndCart(int ProductId)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Product.ProductId == ProductId)
                {
                    cart.Remove(item);
                    break;
                }
            }

            if (cart.Count == 0)
            {
                Session["cart"] = null;
            }
            else
            {
                Session["cart"] = cart;
            }
            return RedirectToAction("Checkout");
        }

        public ActionResult IncressQuantity(int ProductId)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Product.ProductId == ProductId)
                {
                    item.Quantity++;
                    break;
                }
            }
            return RedirectToAction("Checkout");
        }

        public ActionResult DecressQuantity(int ProductId)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Product.ProductId == ProductId)
                {
                    if (item.Quantity > 1)
                    {
                        item.Quantity--;
                        break;
                    }
                    else
                    {
                        item.Quantity = 1;
                    }

                }
            }
            return RedirectToAction("Checkout");
        }


        public ActionResult PlaceOrder()
        {
            List<CartItem> cartItems = (List<CartItem>)Session["cart"];
            decimal total = 0;
            foreach (var item in cartItems)
            {
                total += item.Quantity * item.Product.Price;
            }
            var userId = (int)Session["UserId"];
            User user = _user.GetUserById(userId);
            Order order = new Order()
            {
                CustomerId = user.UserId,
                CurrancyId = 1,
                ShippedDate = DateTime.Now,
                TotalPrice = total,
                ShipAddress = user.Email,
                OrderStatus = OrderStatus.Processing
            };
            _order.SaveOrder(order);

            foreach (var item in cartItems)
            {
                OrderDetaills orderDetail = new OrderDetaills()
                {
                    OrderId = order.OrderId,
                    ProductId = item.Product.ProductId,
                    LicanceId = 2,
                    Quantity = (short)item.Quantity,
                    Price = item.Product.Price
                };
                _orderDetail.SaveOrderDetail(orderDetail);
            };
            Session["cart"] = null;
            return View("PlaceOrder");
        }


    }
}