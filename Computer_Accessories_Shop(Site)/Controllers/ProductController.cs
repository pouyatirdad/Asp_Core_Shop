using Computer_Accessories_Shop.Api.ViewModel.Products;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StorePanel.Infrastructure.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop.Api.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService ProductService;
        public ProductController(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetAll();
        }
        [HttpGet("Get/{id:int}")]
        public Product Get(int id)
        {
            var findedReslut = ProductService.GetById(id);
            return findedReslut;
        }
        [HttpPost("Create")]
        public async Task<bool> Create([FromForm]ProductViewModel model)
        {
            if (model.ProductCategoryID == 0)
                model.ProductCategoryID = null;

            if (model.File != null)
            {
                var imageName = await ImageHelper.SaveImage(model.File, 670, 400, true);
                model.Image = imageName;
            }

            var newModel=new Product()
            {
                Title = model.Title,
                ShortDescription=model.ShortDescription,
                Description = model.Description,
                Price = model.Price,
                Discount = model.Discount,
                Image=model.Image,
                Rate=model.Rate,
                ProductCategoryID =model.ProductCategoryID,
            };

            return ProductService.Create(newModel);
        }
        [HttpPost("Edit")]
        public async Task<bool> Edit([FromForm]ProductViewModel model)
        {
            if (model.ProductCategoryID == 0)
                model.ProductCategoryID = null;

            if (model.File != null)
            {
                var imageName = await ImageHelper.SaveImage(model.File, 670, 400, true);
                model.Image = imageName;
            }

            var newModel = new Product()
            {
                ID = model.ID,
                Title = model.Title,
                ShortDescription = model.ShortDescription,
                Description = model.Description,
                Price = model.Price,
                Discount = model.Discount,
                Image = model.Image,
                Rate = model.Rate,
                ProductCategoryID = model.ProductCategoryID,
            };

            return ProductService.Edit(newModel);
        }
        [HttpPost("Delete")]
        public bool Delete(int id)
        {
            return ProductService.Delete(id);
        }
    }
}
