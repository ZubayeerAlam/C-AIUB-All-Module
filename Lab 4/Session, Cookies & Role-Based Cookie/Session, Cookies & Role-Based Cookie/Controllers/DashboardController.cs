using Microsoft.AspNetCore.Mvc;

namespace Session__Cookies___Role_Based_Cookie.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
