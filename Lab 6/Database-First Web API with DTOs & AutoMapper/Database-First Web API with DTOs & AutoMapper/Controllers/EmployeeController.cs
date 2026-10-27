using Microsoft.AspNetCore.Mvc;

namespace Database_First_Web_API_with_DTOs___AutoMapper.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
