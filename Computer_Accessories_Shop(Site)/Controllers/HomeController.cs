using Microsoft.AspNetCore.Mvc;

namespace Computer_Accessories_Shop_Site_.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
