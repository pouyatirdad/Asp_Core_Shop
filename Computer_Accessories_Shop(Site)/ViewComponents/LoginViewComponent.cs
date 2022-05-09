using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop_Site_.ViewComponents
{

    public class LoginViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
