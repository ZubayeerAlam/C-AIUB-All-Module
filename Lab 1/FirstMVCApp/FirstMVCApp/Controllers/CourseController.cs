using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
