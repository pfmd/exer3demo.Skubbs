using Microsoft.AspNetCore.Mvc;

namespace exer3demo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateEdit(int id)
        {
            ViewData["editid"] = id;
            return View();
        }
    }
}
