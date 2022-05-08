using Computer_Accessories_Shop.Api.ViewModel.Products;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Computer_Accessories_Shop.Api.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class ProductCommentController : Controller
    {
        private readonly IProductCommentService ProductCommentService;
        public ProductCommentController(IProductCommentService ProductCommentService)
        {
            this.ProductCommentService = ProductCommentService;
        }

        [HttpGet]
        public IEnumerable<ProductComment> Get()
        {
            return ProductCommentService.GetAll();
        }
        [HttpGet("Get/{id:int}")]
        public ProductComment Get(int id)
        {
            var findedReslut = ProductCommentService.GetById(id);
            return findedReslut;
        }
        [HttpPost("Create")]
        public bool Create(ProductCommentViewModel model)
        {
            if (model.ParentId == 0)
                model.ParentId = null;

            var newModel=new ProductComment()
            {
                Name = model.Name,
                Email = model.Email,
                Message = model.Message,
                AddedDate = model.AddedDate,
                Rate = model.Rate,
                ParentId = model.ParentId,
                ProductID = model.ProductID,
            };

            return ProductCommentService.Create(newModel);
        }
        [HttpPost("Edit")]
        public bool Edit(ProductCommentViewModel model)
        {
            if (model.ParentId == 0)
                model.ParentId = null;

            var newModel = new ProductComment()
            {
                ID = model.ID,
                Name = model.Name,
                Email = model.Email,
                Message = model.Message,
                AddedDate = model.AddedDate,
                Rate = model.Rate,
                ParentId=model.ParentId,
                ProductID=model.ProductID,
            };

            return ProductCommentService.Edit(newModel);
        }
        [HttpPost("Delete")]
        public bool Delete(int id)
        {
            return ProductCommentService.Delete(id);
        }
    }
}
