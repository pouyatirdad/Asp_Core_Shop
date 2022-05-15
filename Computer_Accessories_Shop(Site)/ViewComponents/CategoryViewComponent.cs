using Computer_Accessories_Shop.Service.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop_Site_.ViewComponents
{

    public class CategoryViewComponent : ViewComponent
    {
        private readonly IProductCategoryService productCategoryService;
        public CategoryViewComponent(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = productCategoryService.GetAll();
            return View(model);
        }
    }
}
