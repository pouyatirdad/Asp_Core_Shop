using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop_Site_.ViewComponents
{

    public class RegisterViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
