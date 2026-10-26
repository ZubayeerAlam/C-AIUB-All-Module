using Microsoft.AspNetCore.Mvc;

namespace routing_and_views_working.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
