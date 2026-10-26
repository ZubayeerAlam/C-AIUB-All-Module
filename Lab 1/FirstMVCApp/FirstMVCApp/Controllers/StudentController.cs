using Microsoft.AspNetCore.Mvc;
namespace FirstMVCApp.Controllers
{
    public class StudentController : Controller
    {
        // Displays the student list page 
        public IActionResult Student()
        {
            ViewBag.Title = "Student List";
            ViewBag.Message = "Welcome to the Student Module";
            return View();
        }
        // Displays details for a specific student 
        public IActionResult Details(int id)
        {
            ViewBag.StudentId = id;
            return View();
        }
        // Returns plain text — no view required 
        public IActionResult About()
        {
            return Content("This is the Student module.");
        }
    }
}