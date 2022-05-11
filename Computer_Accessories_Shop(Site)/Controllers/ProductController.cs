﻿using Computer_Accessories_Shop.Api.ViewModel.Products;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorePanel.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService ProductService;
        public ProductController(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        public IActionResult Index()
        {
            var model = ProductService.GetAll();
            return View(model);
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
        public IActionResult CheckOut()
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

            return View(products);
        }
    }
}
