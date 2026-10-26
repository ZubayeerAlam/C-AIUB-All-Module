using Microsoft.AspNetCore.Mvc;

namespace Session__Cookies___Role_Based_Cookie.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
