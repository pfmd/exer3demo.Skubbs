using exer3demo.Data;
using exer3demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace exer3demo.Controllers
{
    public class EmployeeV2Controller : Controller
    {
        private readonly EmployeeDbContextV2 _context;

        public EmployeeV2Controller(EmployeeDbContextV2 context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Employee> objDiaryEntryList = _context.Employees.ToList();
            return View(objDiaryEntryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {

            if (ModelState.IsValid)
            {
                _context.Employees.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index", "EmployeeV2");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employeeEntry = _context.Employees.Find(id);
            if (employeeEntry == null)
            {
                return NotFound();
            }
            return View(employeeEntry);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            

            if (ModelState.IsValid)
            {
                _context.Employees.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index", "EmployeeV2");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee obj)
        {
            _context.Employees.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index", "EmployeeV2");
        }
    }
}
