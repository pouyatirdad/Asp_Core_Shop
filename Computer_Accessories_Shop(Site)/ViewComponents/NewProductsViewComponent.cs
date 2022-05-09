using Computer_Accessories_Shop.Service.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop_Site_.ViewComponents
{

    public class NewProductsViewComponent : ViewComponent
    {

        private readonly IProductService ProductService;
        public NewProductsViewComponent(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = ProductService.GetProductsByAddedDate(20);
            return View(model);
        }
    }
}
