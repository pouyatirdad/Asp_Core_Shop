﻿using Computer_Accessories_Shop.Api.ViewModel.Products;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorePanel.Infrastructure.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop.Api.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        [HttpGet]
        public IEnumerable<ProductCategory> Get()
        {
            return productCategoryService.GetAll();
        }
        [HttpGet("Get/{id:int}")]
        public ProductCategory Get(int id)
        {
            var findedReslut = productCategoryService.GetById(id);
            return findedReslut;
        }

    }
}
