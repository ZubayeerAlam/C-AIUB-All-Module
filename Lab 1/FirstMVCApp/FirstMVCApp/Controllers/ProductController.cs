using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
