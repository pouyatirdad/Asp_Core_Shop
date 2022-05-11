using Computer_Accessories_Shop.Api.ViewModel.Products;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorePanel.Infrastructure.Helpers;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop_Site_.Controllers
{
    [Authorize(Roles = "Programmer")]
    public class AdminController : Controller
    {
        private readonly IProductCategoryService productCategoryService;
        private readonly IProductService ProductService;
        public AdminController(IProductCategoryService productCategoryService, IProductService ProductService)
        {
            this.productCategoryService = productCategoryService;
            this.ProductService = ProductService;
        }
        public IActionResult Index()
        {
            return View();
        }
        //productCategory
        [HttpGet]
        public IActionResult ProductCategory()
        {
            var model = productCategoryService.GetAll();
            return View(model);
        }
        [HttpGet]
        public IActionResult ProductCategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductCategoryCreate(ProductCategoryViewModel model)
        {
            if (model.ParentID == 0)
                model.ParentID = null;

            if (model.File != null)
            {
                var imageName = await ImageHelper.SaveImage(model.File, 670, 400, true);
                model.Image = imageName;
            }

            var newModel = new ProductCategory()
            {
                Title = model.Title,
                Image = model.Image,
                ParentID = model.ParentID,
            };

            bool result = productCategoryService.Create(newModel);

            if (result == true)
                return RedirectToAction("index");

            return View();
        }
        [HttpGet]
        public IActionResult ProductCategoryEdit(int id)
        {
            var model = productCategoryService.GetById(id);
            var newModel = new ProductCategoryViewModel()
            {
                ID = model.ID,
                Title = model.Title,
                Image = model.Image,
                ParentID = model.ParentID,
            };
            return View(newModel);
        }
        [HttpPost]
        public async Task<IActionResult> ProductCategoryEdit(ProductCategoryViewModel model)
        {
            if (model.ParentID == 0)
                model.ParentID = null;

            if (model.File != null)
            {
                var imageName = await ImageHelper.SaveImage(model.File, 670, 400, true);
                model.Image = imageName;
            }

            var newModel = new ProductCategory()
            {
                ID = model.ID,
                Title = model.Title,
                Image = model.Image,
                ParentID = model.ParentID,
            };

            bool result = productCategoryService.Edit(newModel);

            if (result == true)
                return RedirectToAction("index");

            return View();
        }
        [HttpGet]
        public IActionResult ProductCategoryDelete(int id)
        {
            productCategoryService.Delete(id);

            return RedirectToAction("index");
        }


        //products
        [HttpGet]
        public IActionResult Products(int catId)
        {
            ViewBag.catId = catId;
            var model = ProductService.GetProductsByCatId(catId);
            return View(model);
        }
        public IActionResult ProductCreate(int catId)
        {
            ViewBag.catId = catId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductViewModel model)
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
                Title = model.Title,
                ShortDescription = model.ShortDescription,
                Description = model.Description,
                Price = model.Price,
                AddedDate=System.DateTime.Now,
                Discount = model.Discount & 0,
                Image = model.Image,
                Rate = model.Rate,
                ProductCategoryID = model.ProductCategoryID,
            };

            bool result = ProductService.Create(newModel);

            if (result == true)
                return RedirectToAction("index");

            return View();
        }
        [HttpGet]
        public IActionResult ProductEdit(int Id)
        {
            ViewBag.Id = Id;

            var model = ProductService.GetById(Id);
            var newModel = new ProductViewModel()
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
            return View(newModel);
        }
        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductViewModel model)
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

            bool result = ProductService.Edit(newModel);

            if (result == true)
                return RedirectToAction("index");

            return View();
        }
        [HttpGet]
        public IActionResult ProductDelete(int id)
        {
            ProductService.Delete(id);

            return RedirectToAction("index");
        }

    }
}
