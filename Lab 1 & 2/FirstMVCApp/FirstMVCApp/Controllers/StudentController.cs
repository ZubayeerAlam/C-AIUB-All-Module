using Microsoft.AspNetCore.Mvc;
namespace FirstMVCApp.Controllers
{
    public class StudentController : Controller
    {
        // Displays the student list page 
        public IActionResult Student()
        {
            ViewBag.Title = "Student List";
            ViewData["SubTitle"] = "Enrolled students this semester";

            var students = new List<string>
    {
        "Alice Rahman", "Bob Hasan", "Carol Akter", "David Khan"
    };

            return View(students);
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