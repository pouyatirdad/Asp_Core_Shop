using Computer_Accessories_Shop.Service.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop_Site_.ViewComponents
{

    public class DiscountProductsViewComponent : ViewComponent
    {

        private readonly IProductService ProductService;
        public DiscountProductsViewComponent(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = ProductService.GetProductsHasDiscount(10);
            return View(model);
        }
    }
}
