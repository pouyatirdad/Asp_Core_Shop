using Computer_Accessories_Shop.Api.ViewModel.Products;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StorePanel.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService ProductService;
        private readonly IOrderService orderService;
        private readonly UserManager<User> userManager;

        public ProductController(IProductService ProductService,IOrderService orderService, UserManager<User> userManager)
        {
            this.ProductService = ProductService;
            this.orderService = orderService;
            this.userManager = userManager;
        }

        public IActionResult Index(int page = 1, int pageSize = 9, int? ProductCategoryId = null)
        {

            int paresh = (page - 1) * pageSize;
            ViewBag.PageID = page;
            ViewBag.PageSize = pageSize;
            var products = new List<Product> { };
            if (ProductCategoryId == null)
            {
                products = ProductService.GetAll().ToList();
            }
            else
            {
                products = ProductService.GetAll().Where(x => x.ProductCategoryID == ProductCategoryId).ToList();
            }

            int totalCount = products.Count();
            ViewBag.All = totalCount;

            return View(products.Skip(paresh).Take(pageSize).ToList());
        }

        [HttpPost]
        public IActionResult SearchResult(string txtstring)
        {
            ViewBag.searchString = txtstring;
            var products = ProductService.GetAll().Where(x=>x.Title.Contains(txtstring)).ToList();

            return View(products);
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var findedReslut = ProductService.GetById(id);
            return View(findedReslut);
        }
        [HttpPost]
        public bool AddToCart(int id)
        {
            try
            {
                List<int> items = new List<int>();

                string PrevValue = GetCoockie("cart");
                if (PrevValue != null)
                {
                    var PrevList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(PrevValue);

                    for (int i = 0; i < PrevList.Count; i++)
                    {
                        items.Add(PrevList[i]);
                    }
                }

                items.Add(id);

                var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(items);

                SetCoockie("cart", jsonStr, 10);

                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

        public int GetCartItemNumber()
        {
            var items = new List<int>();
            string PrevValue = GetCoockie("cart");
            if (PrevValue != null)
            {
                items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(PrevValue);
            }

            return items.Count;
        }
        public string GetCoockie(string key)
        {
            string cookieValue = Request.Cookies[key];

            return cookieValue;
        }

        public void SetCoockie(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddDays(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddDays(7);

            Response.Cookies.Append(key, value, option);
        }

        public IActionResult Cart()
        {
            List<Product> products = new List<Product>();

            string PrevValue = GetCoockie("cart");
            if (PrevValue != null)
            {
                var PrevList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(PrevValue);

                for (int i = 0; i < PrevList.Count; i++)
                {
                    var product = ProductService.GetById(PrevList[i]);
                    products.Add(product);
                }

            }

            return View(products);
        }
        [Authorize]
        public IActionResult CheckOut()
        {
            List<Product> products = new List<Product>();



            string PrevValue = GetCoockie("cart");
            if (PrevValue != null)
            {
                Order order = new Order();
                decimal totalPrice = 0;
                int Quality = 0;

                var PrevList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(PrevValue);

                for (int i = 0; i < PrevList.Count; i++)
                {
                    Quality += 1;
                    var product = ProductService.GetById(PrevList[i]);
                    totalPrice +=product.Price;
                    products.Add(product);
                }

                order.Price = totalPrice;
                order.Products = products;
                order.Quality = Quality;
                order.OrderDate = DateTime.Now;
                order.User_Name = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!orderService.Create(order))
                {
                    throw new Exception("order not created");
                }

            }

            return View(products);
        }
        [HttpPost]
        public IActionResult ShowFactor()
        {
            List<Product> products = new List<Product>();

            string PrevValue = GetCoockie("cart");
            if (PrevValue != null)
            {
                var PrevList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(PrevValue);

                for (int i = 0; i < PrevList.Count; i++)
                {
                    var product = ProductService.GetById(PrevList[i]);
                    products.Add(product);
                }

            }

            Response.Cookies.Delete("cart");
            return View(products);
        }
    }
}
