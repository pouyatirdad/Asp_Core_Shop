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
    public class ProductGalleryController : Controller
    {
        private readonly IProductGalleryService ProductGalleryService;
        public ProductGalleryController(IProductGalleryService ProductGalleryService)
        {
            this.ProductGalleryService = ProductGalleryService;
        }

        [HttpGet]
        public IEnumerable<ProductGallery> Get()
        {
            return ProductGalleryService.GetAll();
        }
        [HttpGet("Get/{id:int}")]
        public ProductGallery Get(int id)
        {
            var findedReslut = ProductGalleryService.GetById(id);
            return findedReslut;
        }
        [HttpPost("Create")]
        public async Task<bool> Create([FromForm] ProductGalleryViewModel model)
        {
            if (model.File != null)
            {
                var imageName = await ImageHelper.SaveImage(model.File, 670, 400, true);
                model.Image = imageName;
            }

            var newModel=new ProductGallery()
            {
                Title = model.Title,
                Image=model.Image,
                ProductID=model.ProductID,
            };

            return ProductGalleryService.Create(newModel);
        }
        [HttpPost("Edit")]
        public async Task<bool> Edit([FromForm]ProductGalleryViewModel model)
        {
            if (model.File != null)
            {
                var imageName = await ImageHelper.SaveImage(model.File, 670, 400, true);
                model.Image = imageName;
            }

            var newModel = new ProductGallery()
            {
                ID = model.ID,
                Title = model.Title,
                Image = model.Image,
                ProductID = model.ProductID,
            };

            return ProductGalleryService.Edit(newModel);
        }
        [HttpPost("Delete")]
        public bool Delete(int id)
        {
            return ProductGalleryService.Delete(id);
        }
    }
}
